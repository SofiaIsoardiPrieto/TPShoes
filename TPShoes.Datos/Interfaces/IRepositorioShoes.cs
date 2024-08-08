using TPShoes.Entidades;
using TPShoes.Entidades.Clases;
using TPShoes.Entidades.Dtos;
using TPShoes.Entidades.Enum;

namespace TPShoes.Datos.Interfaces
{
    public interface IRepositorioShoes
    {
        bool Existe(Shoe shoe);
        int GetCantidad(Func<Shoe, bool>? filtro);
        List<Shoe> GetLista();
        List<ShoeDto> GetListaPaginadaOrdenadaFiltrada(int cantidadPorPagina,
            int paginaActual, Orden? orden = null, Brand? BrandFiltro = null,
            Colour? ColourFiltro = null);
      
        IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadosPorGenre();
        IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadosPorSport();
        void Agregar(Shoe shoe);
        void Editar(Shoe shoe);
        Shoe GetShoePorId(int shoeId);
        void EliminarRelaciones(Shoe shoe);
        void Borrar(Shoe shoe);
        bool ExisteRelacion(Shoe shoe, Size size);
        void AsignarSizeAShoe(SizeShoe nuevoSizeShoe);
        List<ShoeDto> GetListaDto();
        IEnumerable<ShoeDto> GetShoesFiltradosPorBrandYColour(int brandId, int colourId);
    }
}
