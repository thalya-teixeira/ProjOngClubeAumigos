using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjOngClubeAumigos.Model;

namespace ProjOngClubeAumigos.Repository
{
    public interface IAdotanteRepository
    {
        //declaração dos métodos (contratos)
        bool Add(Adotante adotante);

        bool VerifCPF(string CPF);
        
        List<Adotante> GetAll();

        List<Adotante> GetAllCPF();
    }
}
