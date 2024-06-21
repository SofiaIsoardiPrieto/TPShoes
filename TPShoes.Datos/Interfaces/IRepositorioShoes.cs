using TPShoes.Entidades.Clases;

namespace TPShoes.Datos.Interfaces
{
    public interface IRepositorioShoes
    {
        bool Existe(Shoe shoe);
        int GetCantidad(Func<Shoe, bool>? filtro);
        List<Shoe> GetLista();
        List<Shoe> GetListaPaginadaOrdenadaFiltrada(int page, int pageSize);
        IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadosPorColourYBrand();
        IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadosPorGenre();
        IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadosPorSport();
        void Guardar(Shoe shoe);
    }
}
