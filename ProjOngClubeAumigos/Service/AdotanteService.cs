using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjOngClubeAumigos.Model;
using ProjOngClubeAumigos.Repository;

namespace ProjOngClubeAumigos.Service
{
    public class AdotanteService
    {
        private IAdotanteRepository _adotanteRepository; 

        public AdotanteService()
        {
            _adotanteRepository = new AdotanteRepository();
        }

        #region Insert
        public bool Add(Adotante adotante)
        {
            return _adotanteRepository.Add(adotante);
        }
        #endregion

        #region Select
        public List<Adotante> GetAll()
        {
            return _adotanteRepository.GetAll();
        }
        #endregion

        public List<Adotante> GetAllCPF()
        {
            return _adotanteRepository.GetAllCPF();
        }

        public bool VerifCPF(string CPF)
        {
            return _adotanteRepository.VerifCPF(CPF);
        }

        public Adotante GetAdotante(string CPF)
        {
            return _adotanteRepository.GetAdotante(CPF);
        }

        public bool Update(Adotante adotante)
        {
            return _adotanteRepository.Update(adotante);
        }

        public bool Delete(Adotante adotante)
        {
            return _adotanteRepository.Delete(adotante);
        }
    }
}
