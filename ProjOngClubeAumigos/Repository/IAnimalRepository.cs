using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjOngClubeAumigos.Model;

namespace ProjOngClubeAumigos.Repository
{
    public interface IAnimalRepository
    {
        //declaração dos métodos (contratos)
        bool Add(Animal animal);

        List<Animal> GetAll();

        List<Animal> GetAllNum_Chip();
    }
}
