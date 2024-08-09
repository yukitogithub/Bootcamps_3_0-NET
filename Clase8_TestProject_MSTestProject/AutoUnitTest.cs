using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase8_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NuGet.Frameworks;

namespace Clase8_TestProject_MSTestProject
{
    [TestClass]
    public class AutoUnitTest
    {
        private Mock<Persona> _persona;
        private Auto _auto;

        [TestInitialize]
        public void Inicializar()
        {
            //Auto no tiene constructor por defecto, por lo que no se puede hacer un Mock de Auto, y no nos conviene tampoco
            _auto = new Auto("Test", "Test", "Test", "Test", 0, 4, false);
            //Para el caso de Persona, sí tiene constructor por defecto, por lo que podemos hacer un Mock de Persona
            //Lo podemos hacer acá o en el test del método SubirConductor, donde se va a usar. En este caso lo hacemos en el TestSubirConductor
            //_persona = new Mock<Persona>();
            //_auto.SubirConductor(_persona.Object);
        }

        [TestMethod]
        public void TestEncender()
        {
            //Act
            _auto.Encender();

            //Assert
            Assert.IsTrue(_auto.Encendido);
        }

        [TestMethod]
        public void TestApagar()
        {
            //Act
            _auto.Apagar();

            //Assert
            Assert.IsFalse(_auto.Encendido);
        }

        [TestMethod]
        public void TestAcelerar()
        {
            //Arrange
            int velocidad = 10;
            int resultadoEsperado = 10;

            //Act
            _auto.Acelerar(velocidad);

            //Assert
            Assert.AreEqual(resultadoEsperado, _auto.Velocidad);
        }

        [TestMethod]
        public void TestFrenar()
        {
            //Arrange
            int velocidadAntesDelFrenado = _auto.Velocidad;
            int decremento = 5;
            int resultadoEsperado = velocidadAntesDelFrenado - decremento;

            //Act
            _auto.Frenar(decremento);

            //Assert
            Assert.AreEqual(resultadoEsperado, _auto.Velocidad);
        }

        [TestMethod]
        public void TestSubirConductor()
        {
            //Arrange
            _persona = new Mock<Persona>();

            //Act
            _auto.SubirConductor(_persona.Object);

            //Assert
            //Para el caso de Mock de un Object, se puede hacer de las siguientes maneras
            //Preguntar primero si la propiedad no es nula
            Assert.IsNotNull(_auto.Conductor);
            //Preguntar si es del tipo esperado
            Assert.IsInstanceOfType(_auto.Conductor, typeof(Persona));
            //Preguntar si es el mismo objeto
            //Esto lo podemos hacer así
            Assert.AreSame(_persona.Object, _auto.Conductor);
            //O así
            Assert.ReferenceEquals(_persona.Object, _auto.Conductor);
            //Y debería ser lo mismo
        }

        [TestMethod]
        public void TestBajarConductor()
        {
            //Act
            _auto.BajarConductor();

            //Assert
            Assert.IsNull(_auto.Conductor);
        }

        [TestCleanup]
        public void Limpiar()
        {
            _auto = null;
            _persona = null;
        }
    }
}
