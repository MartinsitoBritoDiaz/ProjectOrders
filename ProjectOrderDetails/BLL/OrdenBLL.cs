using Microsoft.EntityFrameworkCore;
using ProjectOrderDetails.DAL;
using ProjectOrderDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectOrderDetails.BLL
{
    public class OrdenBLL
    {
        public static bool Guardar(Ordenes orden)
        {
            if (!Existe(orden.ordenId))
                return Insertar(orden);
            else
                return Modificar(orden);
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Orden.Any(o => o.ordenId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Insertar(Ordenes orden)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                ActualizarInventarioProducto(orden);
                contexto.Orden.Add(orden);
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Ordenes orden)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delte FROM OrdenesDetalle Where OrderId = {orden.ordenId}");
                foreach (var auxiliar in orden.OrdenesDetalles)
                {
                    contexto.Database.ExecuteSqlRaw($"INSERT INTO OrdenesDetalle (orderId,productoId,producto,cantidad,costo) " +
                        $"values({auxiliar.ordenId},{auxiliar.productId},{auxiliar.producto},{auxiliar.cantidad},{auxiliar.costo})");
                }
                ActualizarInventarioProducto(orden);
                contexto.Entry(orden).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Ordenes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ordenes orden;

            try
            {
                orden = contexto.Orden
                    .Where(o => o.ordenId == id)
                    .Include(o => o.OrdenesDetalles)
                    .FirstOrDefault();

                orden = contexto.Orden.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return orden;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var orden = contexto.Orden.Find(id);

                if (orden != null)
                {
                    contexto.Orden.Remove(orden);
                    paso = (contexto.SaveChanges() > 0);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static List<Ordenes> GetList(Expression<Func<Ordenes , bool>> criterio)
        {
            List<Ordenes> listaOrdenes = new List<Ordenes>();
            Contexto contexto = new Contexto();

            try
            {
                listaOrdenes = contexto.Orden.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return listaOrdenes;
        }
          
        public static void ActualizarInventarioProducto(Ordenes orden)
        {
            Productos producto = new Productos();

            foreach (var auxiliar in orden.OrdenesDetalles)
            {
                producto = ProductosBLL.Buscar(auxiliar.productId);
                producto.inventario -= auxiliar.cantidad;
                ProductosBLL.Modificar(producto);
            }

        }        
       
    }
}
