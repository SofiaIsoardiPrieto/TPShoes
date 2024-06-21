using Microsoft.EntityFrameworkCore;
using TPShoes.Datos.Interfaces;
using TPShoes.Entidades.Clases;

namespace TPShoes.Datos.Repositorios
{
    public class RepositorioShoes : IRepositorioShoes
    {
        private readonly DBContextShoes _context;

        public RepositorioShoes(DBContextShoes context)
        {
            _context = context;
        }

        public bool Existe(Shoe shoe)
        {
            if (shoe.ShoeId == 0)
            {
                return _context.Shoes
                    .Any(s => s.Model== shoe.Model && s.Price== shoe.Price);
            }
            return _context.Shoes
                .Any(s => s.Model == shoe.Model && s.Price == shoe.Price && s.ShoeId != shoe.ShoeId);
        }

        public int GetCantidad(Func<Shoe, bool>? filtro = null)
        {
            if (filtro != null)
            {
                return _context.Shoes.Count(filtro);
            }
            else
            {

                return _context.Shoes.Count();
            }
        }

        public List<Shoe> GetLista()
        {
            var shoesQuery = _context.Shoes
                .Include(s => s.Brand)
                .Include(s => s.Colour)
                .Include(s => s.Genre)
                .AsNoTracking();

            var shoesSports = shoesQuery
                .Where(s => s.Genre.GenreName == "zapatillas")
                .Include(s => s.Sport)
                .Union(shoesQuery.Where(s => s.Genre.GenreName != "zapatillas"))
                .ToList();

            return shoesSports;
        }

        public List<Shoe> GetListaPaginadaOrdenadaFiltrada(int page, int pageSize)
        {
            IQueryable<Shoe> query = _context.Shoes;
            List<Shoe> listaPaginada = query
                .AsNoTracking()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
            return listaPaginada;
        }
        // falta por Brand tmb
        public IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadosPorColourYBrand()
        {
            return _context.Shoes.GroupBy(s => s.ColourId)
                .ToList();
        }

        public IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadosPorGenre()
        {
            return _context.Shoes.GroupBy(s => s.GenreId)
               .ToList();
        }

        public IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadosPorSport()
        {

            return _context.Shoes.GroupBy(s => s.SportId)
                .ToList();
        }

        public void Guardar(Shoe shoe)
        {
            _context.Shoes.Add(shoe);
        }
    }

}
