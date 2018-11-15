using System;
using System.Collections.Generic;
using System.Text;

namespace Jim.Utils.Filter.Interface
{
    public interface ILogicalConverter
    {
         string Execute(Operators.Logical op);
    }
}
