using Jim.Utils.Filter.Interface;
using Jim.Utils.Filter.Operators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jim.Utils
{
    public class Filtro : IFilter
    {
        private ILogicalConverter _logicalConverter;
        private List<IFilter> items;
        private StringBuilder _sql;
        private int _ocurrencies;
        private const string INITIAL_BLOCK = "(";
        private const string FINAL_BLOCK = ")";
        private Jim.Utils.Filter.Operators.Logical _Operator;
        private const string INIT_WHERE = "WHERE";


        public Filtro(Filter.Operators.Logical Op = Logical.And)
        {
            _sql = new StringBuilder();
            items = new List<IFilter>();
            _ocurrencies = 0;
            _Operator = Op;
            _logicalConverter = new SqlLogicalOperator();
        }

        public void Add(IFilter f)
        {
            items.Add(f);
            _ocurrencies += 1;
        }

        public string ItemOperatorConvert(Logical op)
        {
            return _logicalConverter.Execute(op);
        }

        public string Sql()
        {
            switch (_ocurrencies)
            {
                case 0:
                    throw new Exception("Empty filter");
                case 1:
                    
                    return _sql.Append(items[0].Sql()).ToString(); ;
                default:
                    _sql.Append($" {INITIAL_BLOCK} ");
                    for(int i=0;i<_ocurrencies;i++)
                    {
                        _sql.Append($" {items[i].Sql()} ");
                        if(!IsFinalItem(i))
                        {
                            _sql.Append(OperatorConvert(_Operator));
                        }
                    }
                    _sql.Append($" {FINAL_BLOCK} ");
                    return _sql.ToString();
                   
            }



        }

        private bool IsFinalItem(int pos)
        {
            return (pos + 1) == _ocurrencies;
        }
        private bool isFirstItem(int pos)
        {
            return (pos) == 0;
        }

        public string OperatorConvert(Logical op)
        {
            return _logicalConverter.Execute(op);
        }

        public string Execute()
        {
            return $"{INIT_WHERE} {Sql()}";
        }
    }
}
