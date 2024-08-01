using TPShoes.Entidades.Clases;

namespace TPShoes.Servicios.Interfaces
{
    public interface IGenresServicio
    {
        void Borrar(Genre genre);
        bool EstaRelacionado(Genre genre);
        bool Existe(Genre genre);
        int GetCantidad();
        Genre? GetGenrePorId(int genreId);
        Genre GetGenrePorNombre(string genreNombre);
        List<Genre> GetLista();
        void Guardar(Genre genre);
        
    }
}
