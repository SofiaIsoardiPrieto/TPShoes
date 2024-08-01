using Microsoft.EntityFrameworkCore;
using TPShoes.Datos.Interfaces;
using TPShoes.Entidades.Clases;

namespace TPShoes.Datos.Repositorios
{
    public class RepositorioGenres : IRepositorioGenres
    {
        private readonly DBContextShoes _context;

        public RepositorioGenres(DBContextShoes context)
        {
            _context = context;
        }
        public void Agregar(Genre genre)
        {
            _context.Add(genre);
        }

        public void Borrar(Genre genre)
        {
            _context.Remove(genre);
        }

        public void Editar(Genre genre)
        {
            _context.Update(genre);
        }

        public bool EstaRelacionado(Genre genre)
        {
            return _context
            .Shoes
                .Any(c => c.GenreId == genre.GenreId);
        }
        public int GetCantidad()
        {
            return _context.Genres.Count();
        }

        public bool Existe(Genre genre)
        {
            if (genre.GenreId == 0)
            {
                return _context.Genres
                    .Any(co => co.GenreName == genre.GenreName);
            }
            return _context.Genres
                .Any(co => co.GenreName == genre.GenreName &&
                co.GenreId != genre.GenreId);
        }

        public Genre? GetGenrePorId(int genreId)
        {
            return _context.Genres.FirstOrDefault(g => g.GenreId == genreId);
        }

        public Genre? GetGenrePorNombre(string genreNombre)
        {
            return _context.Genres
                .FirstOrDefault(co => co.GenreName == genreNombre);
        }

        public List<Genre> GetLista()
        {
            return _context.Genres
                .OrderBy(co => co.GenreName)
                .AsNoTracking()
                .ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

}
