using pe.com.tiendita.bo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.tiendita.dal
{
    public class DALProducto
    {
        Conexion objconexion = new Conexion();

        private SqlCommand cmd;
        private SqlDataReader dr;
        int res = 0;

        public List<BOProducto> MostrarProducto()
        {
            List<BOProducto> lista = new List<BOProducto>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarProducto";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    BOProducto objpro = new BOProducto();
                    BOCategoria objcat = new BOCategoria();

                    objpro.codigo = Convert.ToInt32(dr["codpro"].ToString());
                    objpro.nombre = dr["nompro"].ToString();
                    objpro.descripcion = dr["despro"].ToString();
                    objpro.precio = Convert.ToDouble(dr["prepro"].ToString());
                    objpro.cantidad = Convert.ToDouble(dr["canpro"].ToString());
                    objpro.estado = Convert.ToBoolean(dr["estpro"].ToString());
                    //para el codigo
                    objcat.codigo = Convert.ToInt32(dr["codcat"].ToString());
                    //producto
                    objpro.categoria = objcat;
                    lista.Add(objpro);
                }
                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        
        public List<BOProducto> MostrarProductoTodo()
        {
            List<BOProducto> lista = new List<BOProducto>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarTodosLosProductos";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    BOProducto objpro = new BOProducto();
                    BOCategoria objcat = new BOCategoria();

                    objpro.codigo = Convert.ToInt32(dr["codpro"].ToString());
                    objpro.nombre = dr["nompro"].ToString();
                    objpro.descripcion = dr["despro"].ToString();
                    objpro.precio = Convert.ToDouble(dr["prepro"].ToString());
                    objpro.cantidad = Convert.ToDouble(dr["canpro"].ToString());
                    objpro.estado = Convert.ToBoolean(dr["estpro"].ToString());
                    //para el codigo
                    objcat.codigo = Convert.ToInt32(dr["codcat"].ToString());
                    //producto
                    objpro.categoria = objcat;
                    lista.Add(objpro);
                }
                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        public bool RegistrarProducto(BOProducto bp)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarProducto";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@nombre", bp.nombre);
                cmd.Parameters.AddWithValue("@descripcion", bp.descripcion);
                cmd.Parameters.AddWithValue("@precio", bp.precio);
                cmd.Parameters.AddWithValue("@cantidad", bp.cantidad);
                cmd.Parameters.AddWithValue("@estado", bp.estado);
                cmd.Parameters.AddWithValue("@codcat", bp.categoria.codigo);

                res = cmd.ExecuteNonQuery();

                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        public bool ActualizarProducto(BOProducto bp)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarProducto";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", bp.codigo);
                cmd.Parameters.AddWithValue("@nombre", bp.nombre);
                cmd.Parameters.AddWithValue("@descripcion", bp.descripcion);
                cmd.Parameters.AddWithValue("@precio", bp.precio);
                cmd.Parameters.AddWithValue("@cantidad", bp.cantidad);
                cmd.Parameters.AddWithValue("@estado", bp.estado);
                cmd.Parameters.AddWithValue("@codcat", bp.categoria.codigo);

                res = cmd.ExecuteNonQuery();

                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        public bool EliminarProducto(BOProducto bp)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EliminarProducto";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", bp.codigo);

                res = cmd.ExecuteNonQuery();

                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }
    }
}
