using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public class PetComponent
    {
        public Pet Agregar(Pet pet)
        {
            Pet result = default(Pet);
            var petDAC = new PetDAC();

            result = petDAC.Create(pet);
            return result;
        }

        public Pet ObtenerMascota(int id)
        {
            Pet result = default(Pet);
            var petDAC = new PetDAC();

            result = petDAC.ReadBy(id);
            return result;
        }

        public List<Pet> ListarTodos()
        {
            List<Pet> result = default(List<Pet>);

            var petDAC = new PetDAC();
            result = petDAC.Read();
            return result;

        }

        public void ModificarMascota(Pet pet)
        {
            var petDAC = new PetDAC();
            petDAC.Update(pet);
        }

        public void BorrarMascota(Pet pet)
        {
            var petDAC = new PetDAC();
            petDAC.Delete(pet.Id);
        }

    }
}
