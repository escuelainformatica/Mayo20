using LibreriaMayo20.repo;
using LibreriaMayo20.sakila;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace UnitTestLibreriaMayo20
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // https://docs.microsoft.com/en-us/ef/ef6/fundamentals/testing/mocking?redirectedfrom=MSDN

            IQueryable<City> ciudades =new List<City>
            {
                new City {city_id=1,city1="Chile"},
                new City {city_id=2,city1="Argentina"},
                new City {city_id=3,city1="Peru"},
            }.AsQueryable();

            var mockCiudades=new Mock<DbSet<City>>();
            // placeholder
            mockCiudades.As<IQueryable<City>>().Setup(m => m.Provider).Returns(ciudades.Provider);
            mockCiudades.As<IQueryable<City>>().Setup(m => m.Expression).Returns(ciudades.Expression);
            mockCiudades.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(ciudades.ElementType);
            mockCiudades.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(ciudades.GetEnumerator());

            var mockSakila=new Mock<SakilaContexto>();
            mockSakila.Setup(c=>c.city).Returns(mockCiudades.Object);

            var repo=new CityRepo(mockSakila.Object);

            Assert.AreEqual(3,repo.ListarTodo().Count);


            var ciudadNueva=new City {city_id=1,city1="Canada"};
            Assert.AreEqual(1,repo.Insertar(ciudadNueva));

            Assert.AreEqual("Chile",repo.Obtener(1).city1);



            //string[] paises=new string[3] {"Chile","Argentina","Peru"};
            //IEnumerable<string> pais =paises.Where(p=>p=="Chile");
            //var listado=pais.ToList();



        }
    }
}
