using TPShoes.Entidades.Clases;

namespace TPShoes.Datos.Interfaces
{
    public interface IRepositorioSports
    {
        void Agregar(Sport sport);
        void Borrar(Sport sport);
        void Editar(Sport sport);
        bool EstaRelacionado(Sport sport);
        bool Existe(Sport sport);
        List<Sport> GetLista();
        Sport? GetSportPorId(int sportId);
        Sport GetSportPorNombre(string sportNombre);
        void SaveChanges();
        int GetCantidad();
    }

}
