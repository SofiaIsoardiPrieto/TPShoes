using Microsoft.EntityFrameworkCore;
using TPShoes.Datos.Interfaces;
using TPShoes.Entidades;

namespace TPShoes.Datos.Repositorios
{
    public class RepositorioBrands : IRepositorioBrands
    {

        private readonly DBContextShoes _context;

        public RepositorioBrands(DBContextShoes context)
        {
            _context = context;
        }

        public void Agregar(Brand brand)
        {
            _context.Add(brand);
        }

        public void Borrar(Brand brand)
        {
            _context.Remove(brand);
        }

        public void Editar(Brand brand)
        {
            _context.Update(brand);
        }
        //ta bien?
        public bool EstaRelacionado(Brand brand)
        {
            return _context
                .Shoes
                .Any(p => p.BrandId == brand.BrandId);
        }

        public bool Existe(Brand brand)
        {
            if (brand.BrandId == 0)
            {
                return _context.Brands
                    .Any(br => br.BrandName == brand.BrandName);
            }
            return _context.Brands
                .Any(br => br.BrandName == brand.BrandName &&
                br.BrandId != brand.BrandId);
        }

        public Brand? GetBrandPorId(int brandId)
        {
            return _context.Brands.FirstOrDefault(b => b.BrandId == brandId);
        }

        public Brand? GetBrandPorNombre(string brandNombre)
        {
            return _context.Brands
                .FirstOrDefault(br => br.BrandName == brandNombre);
        }

        public List<Brand> GetLista()
        {

            return _context.Brands
                .OrderBy(br => br.BrandName)
                .AsNoTracking()
                .ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

}
