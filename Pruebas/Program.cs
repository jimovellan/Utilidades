using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas
{
    class Program
    {
        public static void Main(string[] args)
        {
            var f = new Jim.Utils.Filtro(Jim.Utils.Filter.Operators.Logical.And);
            f.Add(new Jim.Utils.ItemOperator<DateTime>("Fecha", DateTime.Today));
            f.Add(new Jim.Utils.ItemOperator<int>("Numero", Jim.Utils.Filter.Operators.ItemOperator.GreaterOrEqual, 1));


            var p = new PruebaWrapper(new Prueba());
            Console.WriteLine(f.Sql());
            Console.Read();
        }
    }
}
