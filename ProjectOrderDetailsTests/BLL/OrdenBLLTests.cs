using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOrderDetails.BLL;
using ProjectOrderDetails.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOrderDetails.BLL.Tests
{
    [TestClass()]
    public class OrdenBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Ordenes orden = new Ordenes();
            OrdenesDetalle ordenesDetalle = new OrdenesDetalle();

            orden.ordenId = 0;
            orden.suplidorId = 1;
            orden.fecha = DateTime.Now;
            orden.monto = 20;

            ordenesDetalle.ordenDetalleId = 0;
            ordenesDetalle.ordenId = 0;
            ordenesDetalle.productId = 1;
            ordenesDetalle.producto = "Malta Morena";
            ordenesDetalle.cantidad = 5;
            ordenesDetalle.costo = 500;

            orden.OrdenesDetalles.Add(ordenesDetalle);

            paso = OrdenBLL.Guardar(orden);

            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = OrdenBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            bool paso = false;
            Ordenes orden = new Ordenes();
            OrdenesDetalle ordenesDetalle = new OrdenesDetalle();

            orden.ordenId = 0;
            orden.suplidorId = 1;
            orden.fecha = DateTime.Now;
            orden.monto = 2500;

            ordenesDetalle.ordenDetalleId = 0;
            ordenesDetalle.ordenId = 0;
            ordenesDetalle.productId = 1;
            ordenesDetalle.producto = "Malta Morena";
            ordenesDetalle.cantidad = 5;
            ordenesDetalle.costo = 500;

            orden.OrdenesDetalles.Add(ordenesDetalle);

            paso = OrdenBLL.Insertar(orden);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Ordenes orden = new Ordenes();
            OrdenesDetalle ordenesDetalle = new OrdenesDetalle();

            orden.ordenId = 1;
            orden.suplidorId = 1;
            orden.fecha = DateTime.Now;
            orden.monto = 250;

            paso = OrdenBLL.Modificar(orden);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Ordenes orden = new Ordenes();
            bool paso = false;

            orden = OrdenBLL.Buscar(1);

            if (orden != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;

            paso = OrdenBLL.Eliminar(1);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso = false;

            List<Ordenes> ordenes = OrdenBLL.GetList(o => true);

            if (ordenes != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ActualizarInventarioProductoTest()
        {
            Assert.Fail();
        }
    }
}
