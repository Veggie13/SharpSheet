using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSheet.Engine
{
    class EmptySheet : SheetBase
    {
        private EmptySheet()
        {
            init(new CellFormulaDelegate[0, 0]);
        }

        public static EmptySheet Instance { get; private set; }

        static EmptySheet()
        {
            Instance = new EmptySheet();
        }
    }
}
