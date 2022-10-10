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
            bool result = false;
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                db.Execute(Animal.INSERT, animal); //dapper linha referente ao insert no banco de dados
                result = true;
            }
            return result;
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

        public bool VerifChip(int Num_Chip)
        {

            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var retorno = db.ExecuteScalar(Animal.SELECTCHIP + $"{Num_Chip}");
                if (retorno != null) return true;
                else return false;
            }
            return false;
        }

        public Animal GetAnimal(int Num_Chip)
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var dados = db.Query<Animal>(Animal.SELECT + $" WHERE Num_CHip = {Num_Chip}");
                Animal animal = new()
                {
                    Familia = dados.First().Familia,
                    Nome = dados.First().Nome,
                    Raca = dados.First().Raca,
                    Sexo = dados.First().Sexo,
                    Num_Chip = dados.First().Num_Chip,
                };
                return animal;
            }
        }

        public bool Delete(Animal animal)
        {
            bool result = false;
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                db.Execute(Adotante.DELETE + animal.Num_Chip, animal);
                result = true;
            }
            return result;
        }

        public bool Update(Animal animal)
        {
            bool result = false;
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                db.Execute(Animal.UPDATE, animal);
                result = true;
            }
            return result;
        }
    }
}
