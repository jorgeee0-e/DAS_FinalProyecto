using DAS_ProyectoFinal.Models;

namespace DAS_ProyectoFinal.Servicios
{
    public interface Iservicio_API
    {
        Task<List<Carreras>> Lista();
        Task<Carreras> Obtener(String nombre_carrera);
        Task<bool> Guardar(Carreras objeto);

        Task<List<Noticias>> ListaN();
        Task<Noticias> ObtenerN(string titulo);

        Task<bool> GuardarC(ContactanosInput objeto);
    }
}
