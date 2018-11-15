using System;
using System.Collections.Generic;
using System.Text;
using Jim.Utils.Filter.Operators;

namespace Jim.Utils
{
    public class ItemOperator<T> : IFilter
    {
        private Filter.Operators.ItemOperator _operator;
        private T _Value;
        private const string DATE_FORMAT = "dd-MM-yyy 00:00:000";
        private string field;
        
        public ItemOperator(string Field, T Value)
        {
            _operator = Filter.Operators.ItemOperator.Equal;
            _Value = Value;
            field = Field;
        }
        public ItemOperator(string Field, Filter.Operators.ItemOperator Op,T Value)
        {
            _operator = Op;
            _Value = Value;
            field = Field;
        }


        public string ValueConverter()
        {
            String ValureConverted = "";
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    ValureConverted = _Value.ToString();
                    break;
                case TypeCode.String:
                    ValureConverted = "'" + (_Value as string) + "'";
                    break;
                case TypeCode.DateTime:

                    ValureConverted = "'" + ((DateTime)((object)_Value)).ToString(DATE_FORMAT) + "'";
                    break;
                case TypeCode.Empty:
                    ValureConverted = "NULL";
                    break;
            }
            return ValureConverted;
        }
        public string OperatorConvert(ItemOperator op)
        {
            switch (_operator)
            {
                case ItemOperator.Equal:
                    return "=";
                  
                case ItemOperator.NotEqual:
                    return "<>";
                   
                case ItemOperator.Like:
                    return "LIKE";
                   
                case ItemOperator.Less:
                    return "<";
                  
                case ItemOperator.LessOrEqual:
                    return "<=";
                   
                case ItemOperator.Greater:
                    return ">";
                  
                case ItemOperator.GreaterOrEqual:
                    return ">=";
                   
                default:
                    return "=";
                    
            }
        }

        public string Sql()
        {
            return $"{field} {OperatorConvert(_operator)} {ValueConverter()} ";
        }

        public string GetDATE(DateTime date)
        {
            return "";
        }

        public string OperatorConvert(Logical op)
        {
            throw new NotImplementedException();
        }
    }
}
