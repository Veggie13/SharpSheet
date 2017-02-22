using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using SharpSheet.Document;

namespace SharpSheet.Engine
{
    public static class Generator
    {
        public static Dictionary<string, SheetBase> Generate(Workbook workbook, IEnumerable<string> assemblies)
        {
            assemblies = assemblies.Concat(new[] { System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location) });

            string code = generateCode(workbook, "SharpSheet.Engine");

            var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } });
            var result = csc.CompileAssemblyFromSource(
                new CompilerParameters(assemblies.ToArray(), "generated.dll", false)
                {
                    GenerateExecutable = false,
                    GenerateInMemory = true
                }, code);

            if (result.Errors.Count > 0)
            {
                throw new Exception();
            }

            return result.CompiledAssembly.Modules.First().GetTypes()
                .Where(t => t.GetConstructors().Any())
                .ToDictionary(t => t.Name, t => (SheetBase)t.GetConstructors()[0].Invoke(new object[0]));
        }

        static string generateCode(Workbook workbook, string ns)
        {
            string code = "namespace SharpSheet.Generated { ";

            code += string.Join(" ", workbook.Sheets.Select(s => generateSheetCode(s, ns)));

            code += " } ";

            return code;
        }

        static string generateSheetCode(Sheet sheet, string ns)
        {
            string code = string.Format(@"
                class {0} : {1}.SheetBase {{
                    public {0}() {{
                        init(new {1}.CellFormulaDelegate[,] {{",
                sheet.Name, ns);

            var rowCodes = Enumerable.Range(0, sheet.RowCount)
                .Select(i => sheet.Rows.FirstOrDefault(r => r.Index == i))
                .Select(r => generateRowCode(r, sheet.ColumnCount));
            code += string.Join(", ", rowCodes);
            code += "}); } ";

            var propCodes = Enumerable.Range(0, sheet.RowCount)
                .SelectMany(r => Enumerable.Range(0, sheet.ColumnCount)
                    .Select(c => generateCellPropertyCode(r, c)));
            code += string.Join(" ", propCodes);

            code += " }";

            return code;
        }

        static string generateRowCode(Row row, int colCount)
        {
            var cellCodes = Enumerable.Range(0, colCount)
                .Select(i => row.Cells.FirstOrDefault(c => c.Index == i))
                .Select(c => generateCellCode(c));
            return "{ " + string.Join(", ", cellCodes) + " }";
        }

        static string generateCellCode(Cell cell)
        {
            if (cell == null)
            {
                return "(null)";
            }
            return string.Format("( () => {0} )", cell.Formula);
        }

        static string generateCellPropertyCode(int row, int col)
        {
            return string.Format("public dynamic {0}{1} {{ get {{ return this[{2}, {3}].Value; }} }}",
                Tools.ColumnHeaders.GetCode(col), row + 1, row, col);
        }
    }
}
