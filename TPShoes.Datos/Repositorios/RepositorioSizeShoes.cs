using Microsoft.EntityFrameworkCore;
using TPShoes.Datos.Interfaces;
using TPShoes.Entidades.Clases;
using TPShoes.Entidades.Dtos;
using TPShoes.Entidades.Enum;

namespace TPShoes.Datos.Repositorios
{
    public class RepositorioSizeShoes : IRepositorioSizeShoes
    {
        private readonly DBContextShoes _context;

        public RepositorioSizeShoes(DBContextShoes context)
        {
            _context = context;
        }
        public void Agregar(Entidades.Clases.Size sizes)
        {

            _context.Add(sizes);
        }

        public void AgregarSizeShoe(SizeShoe nuevaRelacion)
        {
            _context.Set<SizeShoe>().Add(nuevaRelacion);
        }


        public void Borrar(Entidades.Clases.Size sizes)
        {
            _context.Remove(sizes);
        }

        public void Borrar(SizeShoe sizeShoe)
        {
            throw new NotImplementedException();
        }

        public void Editar(Entidades.Clases.Size sizes)
        {
            _context.Update(sizes);
        }

        public void Editar(SizeShoe sizeShoe)
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
            throw new NotImplementedException();
        }

        public int GetCantidad()
        {
            return _context.Sizes.Count();
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


        public SizeShoe? GetSizeShoePorId(int sizeShoeId)
        {
            throw new NotImplementedException();
        }

        //public List<Size> GetLista()
        //{
        //    return _context.Sizes.ToList();
        //}

        //public List<Size> GetSizesPaginadosOrdenados(int page, int pageSize, Orden? orden = null)
        //{
        //    IQueryable<Size> query = _context.Sizes;

        //    //ORDEN
        //    if (orden != null)
        //    {
        //        switch (orden)
        //        {
        //            case Orden.AZ:
        //                query = query.OrderBy(s => s.SizeNumber);
        //                break;
        //            case Orden.ZA:
        //                query = query.OrderByDescending(s => s.SizeNumber);
        //                break;
        //            default:
        //                break;
        //        }
        //    }

        //    //PAGINADO
        //    List<Size> listaPaginada = query.AsNoTracking()
        //        .Skip(page * pageSize) //Saltea estos registros
        //    .Take(pageSize) //Muestra estos
        //    .ToList();

        //    return listaPaginada;
        //}

        public List<Entidades.Clases.Size> GetSizesPorId(int shoeId, bool incluyeShoe = false)
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
