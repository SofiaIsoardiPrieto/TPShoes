using TPShoes.Entidades.Clases;

namespace TPShoes.Datos.Interfaces
{
    public interface IRepositorioGenres
    {
        void Agregar(Genre genre);
        void Borrar(Genre genre);
        void Editar(Genre genre);
        bool EstaRelacionado(Genre genre);
        bool Existe(Genre genre);
        Genre? GetGenrePorId(int genreId);
        Genre GetGenrePorNombre(string genreNombre);
        List<Genre> GetLista();
        void SaveChanges();
    }

}
