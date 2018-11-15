using System;
using System.Collections.Generic;
using System.Text;

namespace Jim.Utils
{
    public abstract class LogicalConverterBase
    {
        public abstract string Execute(Filter.Operators.Logical Op);
        
        public abstract string Execute(Filter.Operators.ItemOperator Op);
        
    }
}
