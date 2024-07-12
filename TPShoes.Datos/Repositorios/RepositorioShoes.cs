using Microsoft.EntityFrameworkCore;
using TPShoes.Datos.Interfaces;
using TPShoes.Entidades;
using TPShoes.Entidades.Clases;
using TPShoes.Entidades.Dtos;
using TPShoes.Entidades.Enum;

namespace TPShoes.Datos.Repositorios
{
    public class RepositorioShoes : IRepositorioShoes
    {
        private readonly DBContextShoes _context;

        public RepositorioShoes() { }

        public RepositorioShoes(DBContextShoes context) { _context = context;}

        public bool Existe(Shoe shoe)
        {
            if (shoe.ShoeId == 0)
            {
                return _context.Shoes
                    .Any(s => s.Model == shoe.Model && s.Price == shoe.Price);
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


        public List<ShoeDto> GetListaPaginadaOrdenadaFiltrada
          (int cantidadPorPagina, int paginaActual,
          Orden? orden = null, Brand? BrandFiltro = null,
          Colour? ColourFiltro = null)
        {
            IQueryable<Shoe> query = _context.Shoes
                .Include(p => p.Brand)
                .Include(p => p.Colour)
                .Include(p => p.Genre)
                .Include(p => p.Sport)
                //.Include(p => p.SizeShoe)
                .AsNoTracking();

            // Aplicar filtro si se proporciona un tipo de planta
            if (BrandFiltro != null)
            {
                query = query
                    .Where(p => p.BrandId == BrandFiltro.BrandId);
            }

            // Aplicar filtro si se proporciona un tipo de envase
            if (ColourFiltro != null)
            {
                query = query
                    .Where(p => p.ColourId == ColourFiltro.ColourId);
            }

            // Aplicar orden si se proporciona
            if (orden != null)
            {
                switch (orden)
                {
                    case Orden.AZ:
                        query = query.OrderBy(p => p.Model);
                        break;
                    case Orden.ZA:
                        query = query.OrderByDescending(p => p.Model);
                        break;
                    case Orden.MenorPrecio:
                        query = query.OrderBy(p => p.Price);
                        break;
                    case Orden.MayorPrecio:
                        query = query.OrderByDescending(p => p.Price);
                        break;
                    default:
                        break;
                }
            }

            // Paginar los resultados
            List<Shoe> listaPaginada = query
                .Skip(cantidadPorPagina * (paginaActual - 1))
                .Take(cantidadPorPagina)
                .ToList();

            List<ShoeDto> listaDto = listaPaginada
                .Select(p => new ShoeDto
                {
                    ShoeId = p.ShoeId,
                    Brand = p.Brand?.BrandName ?? "N/A",
                    Genre = p.Genre?.GenreName ?? "N/A",
                    Colour = p.Colour?.ColourName ?? "N/A",
                    Sport = p.Sport?.SportName ?? "N/A",
                    Description = p.Description,
                    Price = p.Price,
                    Model = p.Model
                })
                .ToList();

            return listaDto;
        }

        public IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadosPorColourYBrand()
        {
            // falta por Brand tmb
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

        public void Agregar(Shoe shoe)
        {
            // Verificar si brand asociado a la shoe ya existe en la base de datos:
          
            var brandExistente = _context.Brands
            .FirstOrDefault(t => t.BrandId == shoe.BrandId);

            // Si brand ya existe, adjuntarlo al contexto en lugar de agregarlo nuevamente:
            if (brandExistente != null)
            {
                _context.Attach(brandExistente);
                shoe.Brand = brandExistente;
            }

            //Genre
            var genreExistente = _context.Genres
            .FirstOrDefault(t => t.GenreId == shoe.GenreId);
            if (genreExistente != null)
            {
                _context.Attach(genreExistente);
                shoe.Genre = genreExistente;
            }

            //Colour
            var colourExistente = _context.Colours
            .FirstOrDefault(t => t.ColourId == shoe.ColourId);
            if (colourExistente != null)
            {
                _context.Attach(colourExistente);
                shoe.Colour = colourExistente;
            }

            //Sport
            var sportExistente = _context.Sports
            .FirstOrDefault(t => t.SportId == shoe.SportId);
            if (sportExistente != null)
            {
                _context.Attach(sportExistente);
                shoe.Sport = sportExistente;
            }

            // Agregar la planta al contexto de la base de datos
            _context.Shoes.Add(shoe);
        }

        public void Editar(Shoe shoe)
        {
            var brandExistente = _context.Brands
               .FirstOrDefault(t => t.BrandId == shoe.BrandId);
          
            if (brandExistente != null)
            {
                _context.Attach(brandExistente);
                shoe.Brand = brandExistente;
            }
       
            var sportExistente = _context.Sports
                .FirstOrDefault(t => t.SportId == shoe.SportId);
            if (sportExistente != null)
            {
                _context.Attach(sportExistente);
                shoe.Sport = sportExistente;
            }

            // Verificar si el TipoDeGenero asociado
            // a la Zapatilla ya existe en la base de datos
            var GenreExistente = _context.Genres
              .FirstOrDefault(t => t.GenreId == shoe.GenreId);
            if (GenreExistente != null)
            {
                _context.Attach(GenreExistente);
                shoe.Genre = GenreExistente;
            }
            // Verificar si el TipoDeColor asociado
            // a la Zapatilla ya existe en la base de datos
            var colourExistente = _context.Colours
              .FirstOrDefault(t => t.ColourId == shoe.ColourId);
            if (colourExistente != null)
            {
                _context.Attach(colourExistente);
                shoe.Colour = colourExistente;
            }

            // Agregar la planta al contexto de la base de datos
            _context.Shoes.Update(shoe);
        }

        public Shoe? GetShoePorId(int shoeId)
        {
            return _context.Shoes
                .Include(p => p.Brand)
                 .Include(p => p.Genre)
                 .Include(p => p.SportId)
                 .Include(p => p.ColourId)
                 .FirstOrDefault(p => p.ShoeId == shoeId);
        }
    }

}
