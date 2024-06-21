using TPShoes.Entidades.Clases;

namespace TPShoes.Servicios.Interfaces
{
    public interface ISportsServicio
    {
        void Borrar(Sport sport);
        bool EstaRelacionado(Sport sport);
        bool Existe(Sport sport);
        List<Sport> GetLista();
        Sport? GetSportPorId(int sportId);
        Sport GetSportPorNombre(string sportNombre);
        void Guardar(Sport sport);
    }
}
