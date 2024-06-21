using TPShoes.Entidades;

namespace TPShoes.Servicios.Interfaces
{
    public interface IBrandsServicio
    {
        void Borrar(Brand brand);
        bool EstaRelacionado(Brand brand);
        bool Existe(Brand brand);
        Brand? GetBrandPorId(int brandId);
        Brand GetBrandPorNombre(string brandNombre);
        List<Brand> GetLista();
        void Guardar(Brand brand);
    }
}
