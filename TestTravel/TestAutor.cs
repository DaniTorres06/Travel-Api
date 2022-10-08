using NUnit.Framework;
using Travel_Api.Models;
using Travel_Api.Models.Repository;

namespace TestTravel
{
    [TestFixture]
    internal class TestAutor
    {
        private readonly AutoresRepository _AutorController;

        public TestAutor()
        {
            _AutorController = new AutoresRepository(new Travel_Api.Context.AplicationDbContext());
        }

        [Test]
        public void GetAutoresSucces()
        {
            //Arrange            

            //Act
            var vReslt = _AutorController.GetListAutores();

            //Assert
            Assert.IsTrue(vReslt != null);
        }

        [Test]
        public void GetAutoresNotFound()
        {
            //Arrange            

            //Act
            var vReslt = _AutorController.GetListAutores();

            //Assert
            Assert.IsTrue(vReslt == null);
        }

        [Test]
        public void GetAutoresXIdSucces()
        {
            //Arrange            
            int vIntId = 1;

            //Act
            var vReslt = _AutorController.GetAutoresXId(vIntId);

            //Assert
            Assert.IsTrue(vReslt != null);
        }

        [Test]
        public void GetAutoresXIdNotFound()
        {
            //Arrange
            int vIntId = 151;

            //Act
            var vReslt = _AutorController.GetListAutores();

            //Assert
            Assert.IsTrue(vReslt == null);
        }

        [Test]
        public void AddAutoresSuccess()
        {
            
            var vObjAutor = new Autores();

            //Arrange
            vObjAutor.Id = 721;
            vObjAutor.nombre = "Jose";
            vObjAutor.apellidos = "Perez";

            //Act
            var vReslt = _AutorController.AddAutores(vObjAutor);

            //Assert
            Assert.IsTrue(vReslt != null);
        }



    }
}
