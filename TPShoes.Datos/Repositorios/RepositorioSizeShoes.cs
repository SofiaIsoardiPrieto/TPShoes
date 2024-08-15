using Microsoft.EntityFrameworkCore;
using TPShoes.Datos.Interfaces;
using TPShoes.Entidades.Clases;
using TPShoes.Entidades.Dtos;

namespace TPShoes.Datos.Repositorios
{
    public class RepositorioSizeShoes : IRepositorioSizeShoes
    {
        private readonly DBContextShoes _context;

        public RepositorioSizeShoes(DBContextShoes context)
        {
            _context = context;
        }
        public void Agregar(Size sizes)
        {

            _context.Add(sizes);
        }

        public void AgregarSizeShoe(SizeShoe sizeShoe)
        {
            _context.Set<SizeShoe>().Add(sizeShoe);
        }


        public void Borrar(Entidades.Clases.Size sizes)
        {
            _context.Remove(sizes);
        }

        public void Borrar(SizeShoe sizeShoe)
        {
            _context.Remove(sizeShoe);
        }

        public void Editar(Entidades.Clases.Size sizes)
        {
            _context.Update(sizes);
        }

        public void Editar(SizeShoe sizeShoe)
        {
            _context.Update(sizeShoe);
        }

        public void EditarSizeShoe(SizeShoe sizeShoe)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(Entidades.Clases.Size sizes)
        {
            return _context.Sizes.Any(ss => ss.SizeId == sizes.SizeId);
        }

        public bool EstaRelacionado(SizeShoe size)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Entidades.Clases.Size sizes)
        {
            return _context.Sizes.
                 Any(s => s.SizeId == sizes.SizeNumber
                 && s.SizeId != sizes.SizeId);
        }

        public bool Existe(SizeShoe sizeShoe)
        {
            return _context.SizeShoes.
                  Any(s => s.SizeId == sizeShoe.SizeId
                  && s.SizeId != sizeShoe.SizeId);
        }

        public int GetCantidad()
        {
            return _context.Sizes.Count();
        }

        public List<ShoeDto> GetListaShoeDtoPorSize(int sizeIdSeleccionado)
        {
            try
            {
                // Utilizando Entity Framework para buscar los Shoes por SizeId
                var shoes = _context.SizeShoes
                    .Include(ss => ss.Shoe) // Incluir la entidad relacionada Shoe
                        .ThenInclude(s => s.Brand) // Incluir la entidad relacionada Brand
                    .Include(ss => ss.Shoe)
                        .ThenInclude(s => s.Colour) // Incluir la entidad relacionada Colour
                    .Include(ss => ss.Shoe)
                        .ThenInclude(s => s.Genre) // Incluir la entidad relacionada Genre
                    .Include(ss => ss.Shoe)
                        .ThenInclude(s => s.Sport) // Incluir la entidad relacionada Sport
                    .Where(ss => ss.SizeId == sizeIdSeleccionado)
                    .Select(ss => ss.Shoe)
                    .Distinct() // Eliminar duplicados si un Shoe tiene más de un Size relacionado
                    .AsNoTracking()
                    .ToList();

                // Mapear a ShoeDto
                var shoeDtos = shoes.Select(s => new ShoeDto
                {
                    ShoeId = s.ShoeId,
                    Brand = s.Brand?.BrandName ?? "N/A",
                    Colour = s.Colour?.ColourName ?? "N/A",
                    Genre = s.Genre?.GenreName ?? "N/A",
                    Sport = s.Sport?.SportName ?? "N/A",
                    Model = s.Model,
                    Description = s.Description,
                    Price = s.Price

                }).ToList();

                return shoeDtos;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al obtener la lista de ShoeDto por Size.", ex);
            }
        }



        public List<SizeShoeDto>? GetSizeShoeDtoPorId(int shoeId)
        {
            IQueryable<SizeShoe> query = _context.SizeShoes
                .Include(p => p.Shoe)
                .Include(p => p.Size)
                .AsNoTracking()
                .Where(p => p.ShoeId == shoeId); // Filtro por ShoeId

            // Ejecutar la consulta y obtener la lista de SizeShoe
            List<SizeShoe> lista = query.ToList();

            // Convertir la lista de SizeShoe a una lista de SizeShoeDto
            List<SizeShoeDto> listaDto = lista
                .Select(p => new SizeShoeDto
                {
                    SizeShoeId = p.SizeShoeId,
                    Size = p.Size != null ? p.Size.SizeNumber.ToString() : null,
                    Stok = p.Stok
                })
                .ToList();

            return listaDto;
        }

        public SizeShoe? GetSizeShoePorId(int shoeId, int sizeId)
        {
            try
            {
                // Utilizando Entity Framework para buscar el SizeShoe por ShoeId y SizeId
                var sizeShoe = _context.SizeShoes
                    .Include(ss => ss.Shoe) // Incluir la entidad relacionada Shoe
                    .Include(ss => ss.Size) // Incluir la entidad relacionada Size
                    .FirstOrDefault(ss => ss.ShoeId == shoeId && ss.SizeId == sizeId);

                return sizeShoe;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al obtener el SizeShoe por ShoeId y SizeId.", ex);
            }
        }

        public SizeShoe? GetSizeShoePorId(int sizeShoeId)
        {
            try
            {
                // Utilizando Entity Framework para buscar el SizeShoe por su ID
                var sizeShoe = _context.SizeShoes
                    .Include(ss => ss.Shoe) // Incluir la entidad relacionada Shoe
                    .Include(ss => ss.Size) // Incluir la entidad relacionada Size
                    .FirstOrDefault(ss => ss.SizeShoeId == sizeShoeId);

                return sizeShoe;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al obtener el SizeShoe por ID.", ex);
            }
        }

        public List<Size> GetSizesPorId(int shoeId, bool incluyeShoe = false)
        {
            IQueryable<Entidades.Clases.Size> query = _context.Sizes;

            if (incluyeShoe)
            {
                return query
                    .Include(s => s.SizeShoe)
                    .ThenInclude(ss => ss.Shoe)
                    .Where(s => s.SizeShoe.Any(ss => ss.ShoeId == shoeId))
                    .ToList();
            }

            return query
                .Where(s => s.SizeShoe.Any(ss => ss.ShoeId == shoeId))
                .ToList();
        }

    }
}
