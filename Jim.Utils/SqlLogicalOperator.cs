using System;
using System.Collections.Generic;
using System.Text;
using Jim.Utils.Filter.Operators;

namespace Jim.Utils
{
    public class SqlLogicalOperator : Filter.Interface.ILogicalConverter
    {
        public string Execute(Logical op)
        {
            string StringOperator = "";
            switch (op)
            {
                case Logical.And:
                    StringOperator = "AND";
                    break;
                case Logical.Or:
                    StringOperator = "OR";
                    break;
                default:
                    StringOperator = "AND";
                    break;
            }
            return StringOperator;
        }
    }
}
