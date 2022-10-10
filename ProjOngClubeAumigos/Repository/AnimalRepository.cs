using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ProjOngClubeAumigos.Config;
using ProjOngClubeAumigos.Model;

namespace ProjOngClubeAumigos.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private string _conn; //string de conexão

        public AnimalRepository()
        {
            // _ para atributo privado
            _conn = DataBaseConfiguration.Get();
        }

        public bool Add(Animal animal)
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                db.Execute(Animal.INSERT, animal); //dapper linha referente ao insert no banco de dados
                return true;
            }
            return false;
        }

        public List<Animal> GetAll()
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var animal = db.Query<Animal>(Animal.SELECT);
                return (List<Animal>)animal;
            }
        }

        public List<Animal> GetAllNum_Chip()
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var animal = db.Query<Animal>(Animal.SELECTNum_Chip);
                return (List<Animal>)animal;
            }
        }
    }
}
