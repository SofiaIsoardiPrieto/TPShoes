using System.Numerics;
using TPShoes.Entidades.Clases;

namespace TPShoes.Servicios.Interfaces
{
    public interface IShoesServicio
    {
        void Borrar(int shoeId);
        bool Existe(Shoe shoe);
        int GetCantidad(Func<Shoe, bool>? filtro = null);
        List<Shoe> GetLista();
        List<Shoe> GetListaPaginadaOrdenadaFiltrada(int page, int pageSize);
        Shoe GetShoePorId(int shoeId);
        IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadosPorColourYBrand();
        IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadosPorGenre();
        IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadosPorSport();
      
        void Guardar(Shoe shoe);
    }
}
