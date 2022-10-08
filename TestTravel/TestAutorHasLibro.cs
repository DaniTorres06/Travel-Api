using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Travel_Api.Models;
using Travel_Api.Models.Repository;

namespace TestTravel
{
    [TestFixture]
    internal class TestAutorHasLibro
    {
        private readonly AutoresHasLibrosRepository _autoresHasLibrosRepository;
        public TestAutorHasLibro()
        {
            _autoresHasLibrosRepository = new AutoresHasLibrosRepository(new Travel_Api.Context.AplicationDbContext());
        }

        [Test]
        public void GetAutoresHasLibroSucces()
        {
            //Arrange            

            //Act
            var vResult = _autoresHasLibrosRepository.GetListAutoresHasLibros();

            //Assert
            Assert.IsTrue(vResult != null);
        }

        [Test]
        public void GetAutoresHasLibroNotFound()
        {
            //Arrange            

            //Act
            var vResult = _autoresHasLibrosRepository.GetListAutoresHasLibros();

            //Assert
            Assert.IsTrue(vResult == null);
        }

        [Test]
        public void GetAutoresHasLibroXIdSucces()
        {
            //Arrange            
            int vIntId = 1;

            //Act
            var vReslt = _autoresHasLibrosRepository.GetAutoresHasLibrosXId(vIntId);

            //Assert
            Assert.IsTrue(vReslt != null);
        }

        [Test]
        public void GetAutoresXIdNotFound()
        {
            //Arrange
            int vIntId = 151;

            //Act
            var vResult = _autoresHasLibrosRepository.GetAutoresHasLibrosXId(vIntId);

            //Assert
            Assert.IsTrue(vResult == null);
        }

        [Test]
        public void AddAutoresSuccess()
        {

            var vObjAutorHasLibro = new Autores_has_libros();

            //Arrange
            vObjAutorHasLibro.Id = 721;
            vObjAutorHasLibro.autores_id = 154;
            vObjAutorHasLibro.libros_ISBN = 721;

            //Act
            var vResult = _autoresHasLibrosRepository.AddAutoresHasLibros(vObjAutorHasLibro);

            //Assert
            Assert.IsTrue(vResult != null);
        }
    }
}
