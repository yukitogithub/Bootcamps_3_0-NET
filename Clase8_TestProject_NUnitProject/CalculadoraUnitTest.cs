using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase8_ClassLibrary;

namespace Clase8_TestProject_NUnitProject
{
    [TestFixture] //TestClass en MSTest
    public class CalculadoraUnitTest
    {
        private Calculadora _calculadora;

        [SetUp] //TestInitialize en MSTest
        public void Inicializar()
        {
            _calculadora = new Calculadora();
        }

        [Test] //TestMethod en MSTest
        public void TestSumar()
        {
            //Arrange
            int a = 5;
            int b = 3;
            int resultadoEsperado = 8;

            //Act
            int resultadoObtenido = _calculadora.Sumar(a, b);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [Test]
        public void TestRestar()
        {
            //Arrange
            int a = 5;
            int b = 3;
            int resultadoEsperado = 2;

            //Act
            int resultadoObtenido = _calculadora.Restar(a, b);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [Test]
        public void TestRestarIncorrecto()
        {
            //Arrange
            int a = 5;
            int b = 3;
            int resultadoEsperadoIncorrecto = 3;

            //Act
            int resultadoObtenido = _calculadora.Restar(a, b);

            //Assert
            Assert.AreNotEqual(resultadoEsperadoIncorrecto, resultadoObtenido);
        }

        [Test]
        public void TestRestarNegativo()
        {
            //Arrange
            int a = 5;
            int b = 10;

            //Act
            int resultadoObtenido = _calculadora.Restar(a, b);

            //Assert
            Assert.IsTrue(resultadoObtenido < 0);
        }

        [TearDown] //TestCleanup en MSTest
        public void Limpiar()
        {
            _calculadora = null;
        }
    }
}
