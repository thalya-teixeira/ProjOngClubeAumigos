using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjOngClubeAumigos.Model;
using ProjOngClubeAumigos.Repository;

namespace ProjOngClubeAumigos.Service
{
    public class Controle_AdocaoService
    {

        private IControleAdocaoRepository controleAdocaoRepository;

        public Controle_AdocaoService()
        {
            controleAdocaoRepository = new ControleAdocaoRepository();
        }

        public bool Add(ControleAdocao adocao)
        {
            return controleAdocaoRepository.Add(adocao);
        }

        public List<ControleAdocao> GetAll()
        {
            return controleAdocaoRepository.GetAll();
        }
    }
}
