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
    internal class TestLibro
    {
        private readonly LibroRepository _libroRepository;

        public TestLibro()
        {
            _libroRepository = new LibroRepository(new Travel_Api.Context.AplicationDbContext());
        }

        [Test]
        public void GetLibroSucces()
        {
            //Arrange            

            //Act
            var vResult = _libroRepository.GetListLibros();

            //Assert
            Assert.IsTrue(vResult != null);
        }

        [Test]
        public void GetLibroNotFound()
        {
            //Arrange            

            //Act
            var vResult = _libroRepository.GetListLibros();

            //Assert
            Assert.IsTrue(vResult == null);
        }

        [Test]
        public void GetLibroXIdSucces()
        {
            //Arrange            
            int vIntId = 1;

            //Act
            var vResult = _libroRepository.GetLibrosXId(vIntId);

            //Assert
            Assert.IsTrue(vResult != null);
        }

        [Test]
        public void GetLibroXIdNotFound()
        {
            //Arrange
            int vIntId = 151;

            //Act
            var vResult = _libroRepository.GetLibrosXId(vIntId);

            //Assert
            Assert.IsTrue(vResult == null);
        }

        [Test]
        public void AddLibroSuccess()
        {

            var vObjLibro= new Libros();

            //Arrange
            vObjLibro.Id = 1;
            vObjLibro.ISBN = 64;
            vObjLibro.Editoriales_id = 25;
            vObjLibro.Titulo = "Harry Potter";
            vObjLibro.Sinopsis = "El día en que cumple once años, Harry Potter descubre que es hijo de dos conocidos hechiceros, de los que ha heredado poderes mágicos. Deberá acudir entonces a una famosa escuela de magia y hechicería: Howards.";
            vObjLibro.N_paginas = "264";

            //Act
            var vReslt = _libroRepository.AddLibros(vObjLibro);

            //Assert
            Assert.IsTrue(vReslt != null);
        }
    }
}
