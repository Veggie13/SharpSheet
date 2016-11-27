using System;

namespace SharpSheet.Engine
{
    interface ICellValueProvider
    {
        event Action Modified;
        dynamic GetValue(out ICellValueProvider cellValue);
    }
}
