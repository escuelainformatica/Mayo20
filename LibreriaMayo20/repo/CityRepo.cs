using LibreriaMayo20.sakila;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMayo20.repo
{
    public class CityRepo
    {
        public SakilaContexto sakilaContexto {set; get; }

        public CityRepo(SakilaContexto sakilaContexto)
        {
            this.sakilaContexto = sakilaContexto;
        }

        public List<City> ListarTodo()
        {
            return sakilaContexto.city.ToList();
        }
        public City Obtener(int idCiudad)
        {
            return sakilaContexto.city.Find(idCiudad);
        }
        public int Insertar(City ciudad)
        {
            sakilaContexto.city.Add(ciudad);
            sakilaContexto.SaveChanges();
            return ciudad.city_id;
        }

    }
}
