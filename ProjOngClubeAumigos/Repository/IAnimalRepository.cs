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

        public bool VerifChip(int Num_Chip);

        public Animal GetAnimal(int Num_Chip);

        public bool Update(Animal animal);

        public bool Delete(Animal animal);

    }
}
