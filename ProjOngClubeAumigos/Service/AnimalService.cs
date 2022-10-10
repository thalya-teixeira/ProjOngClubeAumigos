using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjOngClubeAumigos.Model;
using ProjOngClubeAumigos.Repository;

namespace ProjOngClubeAumigos.Service
{
    public class AnimalService
    {
        private IAnimalRepository _animalRepository;

        public AnimalService()
        {
            _animalRepository = new AnimalRepository();
        }

        public bool Add(Animal animal)
        {
            return _animalRepository.Add(animal);
        }

        public List<Animal> GetAll()
        {
            return _animalRepository.GetAll();
        }

        public List<Animal> GetAllNum_Chip()
        {
            return _animalRepository.GetAllNum_Chip();
        }

        public bool VerifChip(int Num_Chip)
        {
            return _animalRepository.VerifChip(Num_Chip);
        }

        public Animal GetAnimal(int Num_Chip)
        {
            return _animalRepository.GetAnimal(Num_Chip);
        }

        public bool Update(Animal animal)
        {
            return _animalRepository.Update(animal);
        }

        public bool Delete(Animal animal)
        {
            return _animalRepository.Delete(animal);
        }
    }
}
