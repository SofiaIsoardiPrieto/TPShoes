using TPShoes.Entidades;

namespace TPShoes.Datos.Interfaces
{
    public interface IRepositorioBrands
    {
        void Agregar(Brand brand);
        void Borrar(Brand brand);
        void Editar(Brand brand);
        bool EstaRelacionado(Brand brand);
        bool Existe(Brand brand);
        Brand? GetBrandPorId(int brandId);
        Brand GetBrandPorNombre(string brandNombre);
        List<Brand> GetLista();
        void SaveChanges();
    }

}
