using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas
{
    public class Prueba
    {
        public int id { get; set; }
        public string Descripcion { get; set; }

    }

    public class PruebaWrapper:Jim.Utils.Entities.Base.EntityWrapper<Prueba>
    {
        public int id { get { return GetProperty<int>(); } set {SetProperty(value); } }
        public string Descripcion { get { return GetProperty<String>(); } set { SetProperty(value); } }


        public PruebaWrapper(Prueba p):base(p)
        {

        }
    }
}
