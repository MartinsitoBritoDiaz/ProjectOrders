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
    public class SuplidoresBLL
    {
        public static bool Guardar(Suplidores suplidor)
        {
            if (!Existe(suplidor.suplidorId))
                return Insertar(suplidor);
            else
                return Modificar(suplidor);
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Suplidor.Any(s => s.suplidorId == id);
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

        public static bool Insertar(Suplidores suplidor)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Suplidor.Add(suplidor);
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

        public static bool Modificar(Suplidores suplidor)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(suplidor).State = EntityState.Modified;
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

        public static Suplidores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Suplidores suplidor;

            try
            {
                suplidor = contexto.Suplidor.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return suplidor;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var suplidor = contexto.Suplidor.Find(id);

                if (suplidor != null)
                {
                    contexto.Suplidor.Remove(suplidor);
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

        public static List<Suplidores> GetList(Expression<Func<Suplidores, bool>> criterio)
        {
            List<Suplidores> listaSuplidores = new List<Suplidores>();
            Contexto contexto = new Contexto();

            try
            {
                listaSuplidores = contexto.Suplidor.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return listaSuplidores;
        }
    }
}
