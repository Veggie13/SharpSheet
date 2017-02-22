using SharpSheet.Engine;
using SharpSheet.Document;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var wb = new Workbook()
            {
                Sheets = new[]
                {
                    new Sheet()
                    {
                        Name = "Sheet1",
                        Cells = new[,] { { "10", "20", "A1 + B1" } }
                    }
                }
            };
            var dict = Generator.Generate(wb, new[] { "mscorlib.dll", "System.Core.dll", "Microsoft.CSharp.dll" });
            var sheet1 = dict["Sheet1"];
        }
    }
}
