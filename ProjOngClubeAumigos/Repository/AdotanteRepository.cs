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

            //bool result = false;

            using (var db = new SqlConnection(_conn))
            {

                db.Open();
                db.Execute(Adotante.INSERT, adotante); //dapper linha referente ao insert no banco de dados
                return true;
                //nao preciso de um close se estou usando o using; objeto de conexão db é destruido apos a utilização do using
            }
            return false;
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
            using(var db = new SqlConnection(_conn))
            {
                db.Open();
                var retorno = db.ExecuteScalar(Adotante.SELECTCPF + $"WHERE CPF = {CPF}");
                if (retorno != null) return true;
                else return false;
            }
            return false;
        }
    }
}
