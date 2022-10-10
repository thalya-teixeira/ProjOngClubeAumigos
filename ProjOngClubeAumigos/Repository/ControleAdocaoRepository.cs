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
    public class ControleAdocaoRepository : IControleAdocaoRepository
    {
        private string _conn; //string de conexão

        public ControleAdocaoRepository()
        {
            // _ para atributo privado
            _conn = DataBaseConfiguration.Get();
        }

        public bool Add(ControleAdocao adocao)
        {
            using (var db = new SqlConnection(_conn))
            {

                db.Open();
                db.Execute(ControleAdocao.INSERT, adocao); //dapper linha referente ao insert no banco de dados
                return true;
                //nao preciso de um close se estou usando o using; objeto de conexão db é destruido apos a utilização do using
            }
            return false;
        }

        public List<ControleAdocao> GetAll()
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var adocao = db.Query<ControleAdocao>(ControleAdocao.SELECTONE);
                return (List<ControleAdocao>)adocao;
            }
        }

        //public List<ControleAdocao> GetAllCPF()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
