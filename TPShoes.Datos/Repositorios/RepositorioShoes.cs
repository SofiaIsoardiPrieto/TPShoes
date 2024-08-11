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

        public RepositorioShoes(DBContextShoes context) { _context = context; }
     
        public bool Existe(Shoe shoe)
        {
            try
            {
                if (shoe.ShoeId == 0)
                {
                    //Este es el cambio que habia que hacer?
                    return _context.Shoes
                        .Any(s => s.Model == shoe.Model && s.BrandId == shoe.BrandId && s.ColourId == shoe.ColourId
                        && s.GenreId == shoe.GenreId && s.SportId == shoe.SportId);
                }
                return _context.Shoes
                    .Any(s => s.Model == shoe.Model && s.BrandId == shoe.BrandId && s.ColourId == shoe.ColourId
                        && s.GenreId == shoe.GenreId && s.SportId == shoe.SportId && s.ShoeId != shoe.ShoeId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad(Func<Shoe, bool>? filtro = null)
        {
            if (filtro != null)
            {
                return _context.Shoes.Count(filtro);
            }
            else
            {
                try
                {
                    return _context.Shoes.Count();
                }
                catch (Exception ex)
                {

                    throw new Exception("Habilita el servidor, boluda!.", ex);
                }
            }
        }
        public List<Shoe> GetLista()
        {
            var shoesQuery = _context.Shoes
                .Include(s => s.Brand)
                .Include(s => s.Colour)
                .Include(s => s.Genre)
                 .Include(s => s.Sport)
                .AsNoTracking();

            return shoesQuery.ToList(); ;
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

            // Aplicar filtro si se proporciona un brand
            if (BrandFiltro is not null)
            {
                query = query
                    .Where(p => p.BrandId == BrandFiltro.BrandId);
            }

            // Aplicar filtro si se proporciona un colour
            if (ColourFiltro is not null)
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

            // Cambio en el paginado, se quitó el -1 y take(paginaAtual)
            List<Shoe> listaPaginada = query
            .AsNoTracking()

                .Skip(cantidadPorPagina * (paginaActual))
                .Take(paginaActual)
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


        public IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadosPorGenre()
        {
            return _context.Shoes.GroupBy(s => s.GenreId)
               .ToList();
        }
        public IEnumerable<IGrouping<int, Shoe>> GetShoesPorMarcaEntreRangoPrecios(decimal rangoMin, decimal rangoMax)
        {
            return _context.Shoes
                .Include(s => s.Brand)
                .Include(s => s.Genre)
                .Include(s => s.Colour)
                .Include(s => s.Sport)
                .Where(s => s.Price >= rangoMin && s.Price <= rangoMax)  // Filtrar por rango de precios
                .GroupBy(s => s.BrandId)
                .ToList();
        }

        public IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadosPorSport()
        {
            return _context.Shoes.GroupBy(s => s.SportId).ToList();
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
            //el problema viena de aca!!!!
            Shoe? shoe =
             _context?.Shoes
                .Include(p => p.Brand)   // Propiedad de navegación
                .Include(p => p.Genre)   // Propiedad de navegación
                .Include(p => p.Sport)   // Propiedad de navegación
                .Include(p => p.Colour)  // Propiedad de navegación
                                         // .AsNoTracking()//sera?
                .FirstOrDefault(p => p.ShoeId == shoeId);

            return shoe;
        }


        public void EliminarRelaciones(Shoe shoe)
        {
            var relacionesPasadas = _context.Shoes
              .Where(pp => pp.ShoeId == shoe.ShoeId)
              .ToList();

            _context.Shoes
                .RemoveRange(relacionesPasadas);
        }

        public void Borrar(Shoe shoe)
        {
            _context.Shoes.Remove(shoe);
        }

        public bool ExisteRelacion(Shoe shoe, Size size)
        {
            if (shoe == null || size == null) return false;

            return _context.SizeShoes
                .Any(pp => pp.ShoeId == shoe.ShoeId
                && pp.SizeId == size.SizeId);
        }

        public void AsignarSizeAShoe(SizeShoe nuevoSizeShoe)
        {
            _context.Set<SizeShoe>().Add(nuevoSizeShoe);
        }

        public List<ShoeDto> GetListaDto()
        {
            var query = _context.Shoes
               .Include(p => p.Brand)
               .Include(p => p.Colour)
               .Include(p => p.Genre)
               .Include(p => p.Sport)
               .AsNoTracking()
               .ToList();

            List<ShoeDto> listaDto = query
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

        public IEnumerable<ShoeDto> GetShoesFiltradosPorBrandYColour(int brandId, int colourId)
        {

            try
            {
                return _context.Shoes
                    .Where(s => s.BrandId == brandId && s.ColourId == colourId)
                    .Select(s => new ShoeDto
                    {
                        ShoeId = s.ShoeId,
                        Brand = s.Brand.BrandName,
                        Colour = s.Colour.ColourName,
                        Sport = s.Sport.SportName,
                        Genre = s.Genre.GenreName,
                        Model = s.Model,
                        Price = s.Price,
                        Description = s.Description
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los Shoes filtrados.", ex);
            }
        }


    }
}

