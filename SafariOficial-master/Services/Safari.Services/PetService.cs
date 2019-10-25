using Safari.Business;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services
{
    public class PetService
    {
        public void BorrarMascota(Pet pet)
        {
            var component = new PetComponent();
            component.BorrarMascota(pet);
        }

        public Pet CrearNuevaMascota(Pet pet)
        {
            var component = new PetComponent();
            var result = component.Agregar(pet);
            return result;
        }

        public Pet ObtenerMascota(int id)
        {
            var component = new PetComponent();
            var result = component.ObtenerMascota(id);
            return result;
        }

        public void ModificarMascota(Pet pet)
        {
            var component = new PetComponent();
            component.ModificarMascota(pet);
        }

        public List<Pet> ObtenerMascotas()
        {
            var component = new PetComponent();
            return component.ListarTodos();
        }
    }
}
