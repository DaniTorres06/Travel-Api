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
    internal class TestEditoriales
    {
        private readonly EditorialesRepository _editorialesRepository;

        public TestEditoriales()
        {
            _editorialesRepository = new EditorialesRepository(new Travel_Api.Context.AplicationDbContext());
        }

        [Test]
        public void GetAutoresSucces()
        {
            //Arrange            

            //Act
            var vResult = _editorialesRepository.GetListEditoriales();

            //Assert
            Assert.IsTrue(vResult != null);
        }

        [Test]
        public void GetAutoresNotFound()
        {
            //Arrange            

            //Act
            var vResult = _editorialesRepository.GetListEditoriales();

            //Assert
            Assert.IsTrue(vResult == null);
        }

        [Test]
        public void GetAutoresXIdSucces()
        {
            //Arrange            
            int vIntId = 1;

            //Act
            var vResult = _editorialesRepository.GetEditorialesXId(vIntId);

            //Assert
            Assert.IsTrue(vResult != null);
        }

        [Test]
        public void GetAutoresXIdNotFound()
        {
            //Arrange
            int vIntId = 151;

            //Act
            var vResult = _editorialesRepository.GetEditorialesXId(vIntId);

            //Assert
            Assert.IsTrue(vResult == null);
        }

        [Test]
        public void AddAutoresSuccess()
        {

            var vObjEditorial = new Editoriales();

            //Arrange
            vObjEditorial.Id = 1;
            vObjEditorial.Nombre = "Las tres casas";
            vObjEditorial.Sede = "Cali";

            //Act
            var vReslt = _editorialesRepository.AddEditoriales(vObjEditorial);

            //Assert
            Assert.IsTrue(vReslt != null);
        }


    }
}
