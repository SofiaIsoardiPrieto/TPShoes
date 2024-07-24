using Microsoft.EntityFrameworkCore;
using TPShoes.Datos.Interfaces;
using TPShoes.Entidades.Clases;
using TPShoes.Entidades.Enum;

namespace TPShoes.Datos.Repositorios
{
    public class RepositorioSizes : IRepositorioSizes
    {
        private readonly DBContextShoes _context;

        public RepositorioSizes(DBContextShoes context)
        {
            _context = context;
        }
        public void Agregar(Size sizes)
        {

            _context.Add(sizes);
        }

        public void AgregarSizeShoe(SizeShoe nuevaRelacion)
        {
            _context.Set<SizeShoe>().Add(nuevaRelacion);
        }


        public void Borrar(Size sizes)
        {
            _context.Remove(sizes);
        }

        public void Editar(Size sizes)
        {
            _context.Update(sizes);
        }

        public bool EstaRelacionado(Size sizes)
        {
            return _context.Sizes.Any(ss => ss.SizeId == sizes.SizeId);
        }

        public bool Existe(Size sizes)
        {
            return _context.Sizes.
                 Any(s => s.SizeId == sizes.SizeNumber
                 && s.SizeId != sizes.SizeId);
        }

        public int GetCantidad()
        {
            return _context.Sizes.Count();
        }

        public List<Size> GetLista()
        {
            return _context.Sizes.ToList();
        }

        public List<Size> GetSizesPaginadosOrdenados(int page, int pageSize, Orden? orden = null)
        {
            IQueryable<Size> query = _context.Sizes;

            //ORDEN
            if (orden != null)
            {
                switch (orden)
                {
                    case Orden.AZ:
                        query = query.OrderBy(s => s.SizeNumber);
                        break;
                    case Orden.ZA:
                        query = query.OrderByDescending(s => s.SizeNumber);
                        break;
                    default:
                        break;
                }
            }

            //PAGINADO
            List<Size> listaPaginada = query.AsNoTracking()
                .Skip(page * pageSize) //Saltea estos registros
            .Take(pageSize) //Muestra estos
            .ToList();

            return listaPaginada;
        }

        public Size? GetSizesPorId(int id, bool incluyeShoe = false)
        {
            //revisar
            var query = _context.Sizes;
            if (incluyeShoe)
            {
                return query.Include(p => p.SizeShoe)
                    //revisar
                    .ThenInclude(pp => pp.Shoe)
                    .FirstOrDefault(p => p.SizeId == id);
            }
            return query
                .FirstOrDefault(p => p.SizeId == id);
        }

    }
}
