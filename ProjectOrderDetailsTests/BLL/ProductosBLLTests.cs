using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOrderDetails.BLL;
using ProjectOrderDetails.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOrderDetails.BLL.Tests
{
    [TestClass()]
    public class ProductosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Productos producto = new Productos();
            bool paso = false;

            producto.productoId = 0;
            producto.inventario = 100;
            producto.descripcion = "Cheetos";
            producto.costo = 50;

            paso = ProductosBLL.Guardar(producto);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = ProductosBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            Productos producto = new Productos();
            bool paso = false;

            producto.productoId = 0;
            producto.inventario = 100;
            producto.descripcion = "Cheetos";
            producto.costo = 50;

            paso = ProductosBLL.Insertar(producto);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Productos producto = new Productos();
            bool paso = false;

            producto.productoId = 1;
            producto.inventario = 100;
            producto.descripcion = "Cheetos";
            producto.costo = 50;

            paso = ProductosBLL.Modificar(producto);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Productos productos = new Productos();
            bool paso = false;

            productos = ProductosBLL.Buscar(1);

            if (productos != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;

            paso = ProductosBLL.Eliminar(1);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso = false;

            List<Productos> productos = ProductosBLL.GetList(o => true);

            if (productos != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }
    }
}