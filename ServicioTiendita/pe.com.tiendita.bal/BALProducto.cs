using pe.com.tiendita.bo;
using pe.com.tiendita.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.tiendita.bal
{
    public class BALProducto
    {
        DALProducto dal = new DALProducto();

        public List<BOProducto> MostrarProducto()
        {
            return dal.MostrarProducto();
        }

        
        public List<BOProducto> MostrarProductoTodo()
        {
            return dal.MostrarProductoTodo();
        }

        public bool RegistrarProducto(BOProducto bp)
        {
            return dal.RegistrarProducto(bp);
        }

        public bool ActualizarProducto(BOProducto bp)
        {
            return dal.ActualizarProducto(bp);
        }

        public bool EliminarProducto(BOProducto bp)
        {
            return dal.EliminarProducto(bp);
        }
        
    }
}
