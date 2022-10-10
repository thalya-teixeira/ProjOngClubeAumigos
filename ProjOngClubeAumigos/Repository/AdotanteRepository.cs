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
    public class AdotanteRepository : IAdotanteRepository
    {
        private string _conn; //string de conexão

        public AdotanteRepository()
        {
            // _ para atributo privado
            _conn = DataBaseConfiguration.Get();
        }

        #region Insert
        public bool Add(Adotante adotante)
        {
            //throw faz com que eu não precise ter um retur; throw lançando uma exceção; throw new NotImplementedException();

            bool result = false;
            using (var db = new SqlConnection(_conn))
            {

                db.Open();
                db.Execute(Adotante.INSERT, adotante); //dapper linha referente ao insert no banco de dados
                result = true;
                //nao preciso de um close se estou usando o using; objeto de conexão db é destruido apos a utilização do using
            }
            return result;
        }
        #endregion

        #region Select
        public List<Adotante> GetAll()
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var adotante = db.Query<Adotante>(Adotante.SELECT);
                return (List<Adotante>)adotante;
                
            }
        }
        #endregion

        public List<Adotante> GetAllCPF()
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var adotante = db.Query<Adotante>(Adotante.SELECT);
                return (List<Adotante>)adotante;

            }
        }

        public bool VerifCPF(string CPF)
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var retorno = db.ExecuteScalar(Adotante.SELECTCPF + CPF);
                if (retorno != null) return true;
                else return false;
            }
            return false;
        }

        public Adotante GetAdotante(string CPF)
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var dados = db.Query<Adotante>(Adotante.SELECT + $" WHERE CPF = {CPF}");
                Adotante adotante = new()
                {
                    CPF = dados.First().CPF,
                    Nome = dados.First().Nome,
                    Sexo = dados.First().Sexo,
                    DataNasc = dados.First().DataNasc,
                    Telefone = dados.First().Telefone,
                    Logradouro = dados.First().Logradouro,
                    Numero = dados.First().Numero,
                    Complemento = dados.First().Complemento,
                    Bairro = dados.First().Bairro,
                    Cidade = dados.First().Cidade,
                    Estado = dados.First().Estado,
                };
                return adotante;
            }
        }

        public bool Update(Adotante adotante)
        {
            bool result = false;
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                db.Execute(Adotante.UPDATE, adotante);
                result = true;
            }
            return result;
        }
        public bool Delete(Adotante adotante)
        {
            bool result = false;
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                db.Execute(Adotante.DELETE + adotante.CPF, adotante);
                result = true;
            }
            return result;
        }
    }
}
