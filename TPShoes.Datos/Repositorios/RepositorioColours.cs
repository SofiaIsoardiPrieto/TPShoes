using Microsoft.EntityFrameworkCore;
using TPShoes.Datos.Interfaces;
using TPShoes.Entidades;
using TPShoes.Entidades.Clases;

namespace TPShoes.Datos.Repositorios
{
    public class RepositorioColours : IRepositorioColours
    {
        private readonly DBContextShoes _context;

        public RepositorioColours(DBContextShoes context)
        {
            _context = context;
        }
        public void Agregar(Colour colour)
        {
            _context.Add(colour);
        }

        public void Borrar(Colour colour)
        {
            _context.Remove(colour);
        }

        public void Editar(Colour colour)
        {
            _context.Update(colour);
        }

        public bool EstaRelacionado(Colour colour)
        {
            return _context
            .Shoes
                .Any(c => c.ColourId == colour.ColourId);
        }

        public bool Existe(Colour colour)
        {
            if (colour.ColourId == 0)
            {
                return _context.Colours
                    .Any(co => co.ColourName == colour.ColourName);
            }
            return _context.Colours
                .Any(co => co.ColourName == colour.ColourName &&
                co.ColourId != colour.ColourId);
        }

        public Colour? GetColourPorId(int colourId)
        {
            return _context.Colours.FirstOrDefault(c => c.ColourId == colourId);
        }

        public Colour? GetColourPorNombre(string colourNombre)
        {
            return _context.Colours
                .FirstOrDefault(co => co.ColourName == colourNombre);
        }

        public List<Colour> GetLista()
        {
            return _context.Colours
                .OrderBy(co => co.ColourName)
                .AsNoTracking()
                .ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

}
