using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOrderDetails.BLL;
using ProjectOrderDetails.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOrderDetails.BLL.Tests
{
    [TestClass()]
    public class SuplidoresBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Suplidores suplidor = new Suplidores();
            bool paso = false;

            suplidor.suplidorId = 0;
            suplidor.Nombre = "La sirena";

            paso = SuplidoresBLL.Guardar(suplidor);

            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = SuplidoresBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            Suplidores suplidor = new Suplidores();
            bool paso = false;

            suplidor.suplidorId = 0;
            suplidor.Nombre = "La sirena";

            paso = SuplidoresBLL.Insertar(suplidor);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Suplidores suplidor = new Suplidores();
            bool paso = false;

            suplidor.suplidorId = 1;
            suplidor.Nombre = "La sirena";

            paso = SuplidoresBLL.Modificar(suplidor);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Suplidores suplidor = new Suplidores();
            bool paso = false;

            suplidor = SuplidoresBLL.Buscar(1);

            if (suplidor != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;

            paso = SuplidoresBLL.Eliminar(1);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso = false;

            List<Suplidores> suplidores = SuplidoresBLL.GetList(o => true);

            if (suplidores != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }
    }
}