using Microsoft.EntityFrameworkCore;
using TPShoes.Datos.Interfaces;
using TPShoes.Entidades;
using TPShoes.Entidades.Clases;

namespace TPShoes.Datos.Repositorios
{
    public class RepositorioSports : IRepositorioSports
    {
        private readonly DBContextShoes _context;

        public RepositorioSports(DBContextShoes context)
        {
            _context = context;
        }
        public void Agregar(Sport sport)
        {
            _context.Add(sport);
        }

        public void Borrar(Sport sport)
        {
            _context.Remove(sport);
        }

        public void Editar(Sport sport)
        {
            _context.Update(sport);
        }
        public int GetCantidad()
        {
            return _context.Sports.Count();
        }

        public bool EstaRelacionado(Sport sport)
        {
            return _context
            .Shoes
                .Any(c => c.SportId == sport.SportId);
        }

        public bool Existe(Sport sport)
        {
            if (sport.SportId == 0)
            {
                return _context.Sports
                    .Any(co => co.SportName == sport.SportName);
            }
            return _context.Sports
                .Any(co => co.SportName == sport.SportName &&
                co.SportId != sport.SportId);
        }

        public Sport? GetSportPorNombre(string sportNombre)
        {
            return _context.Sports
                .FirstOrDefault(co => co.SportName == sportNombre);
        }

        public List<Sport> GetLista()
        {
            return _context.Sports
                .OrderBy(co => co.SportName)
                .AsNoTracking()
                .ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Sport? GetSportPorId(int sportId)
        {
            return _context.Sports.FirstOrDefault(s => s.SportId == sportId);
        }
    }

}
