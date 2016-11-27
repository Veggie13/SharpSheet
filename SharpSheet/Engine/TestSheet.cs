namespace SharpSheet.Engine
{
    class TestSheet : SheetBase
    {
        private TestSheet()
        {
            init(new CellFormulaDelegate[,]
            {
                { testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc },
                { testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc },
                { testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc },
                { testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc },
                { testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc },
                { testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc },
                { testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc },
                { testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc },
                { testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc },
                { testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc },
                { testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc },
                { testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc },
                { testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc },
                { testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc, testFunc }
            });
        }

        public static TestSheet Instance { get; private set; }

        static TestSheet()
        {
            Instance = new TestSheet();
        }

        static dynamic testFunc()
        {
            return 10;
        }
    }
}
