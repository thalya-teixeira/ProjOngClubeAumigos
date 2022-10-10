using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjOngClubeAumigos.Model;

namespace ProjOngClubeAumigos.Repository
{
    public interface IControleAdocaoRepository
    {
        //declaração dos métodos (contratos)
        bool Add(ControleAdocao adocao);

        List<ControleAdocao> GetAll();

        //List<ControleAdocao> GetAllCPF();
    }
}
