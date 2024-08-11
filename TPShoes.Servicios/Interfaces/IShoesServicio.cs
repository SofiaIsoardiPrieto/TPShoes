using System.Numerics;
using TPShoes.Entidades;
using TPShoes.Entidades.Clases;
using TPShoes.Entidades.Dtos;
using TPShoes.Entidades.Enum;

namespace TPShoes.Servicios.Interfaces
{
    public interface IShoesServicio
    {
        void Guardar(Shoe shoe);
        void Editar(Shoe shoe, int? sizeId = null);
        void Borrar(int shoeId);
        bool Existe(Shoe shoe);
        int GetCantidad(Func<Shoe, bool>? filtro = null);
        List<Shoe> GetLista();
        List<ShoeDto> GetListaPaginadaOrdenadaFiltrada(int cantidadPorPagina,
           int paginaActual, Orden? orden = null, Brand? BrandFiltro = null,
           Colour? ColourFiltro = null);
        Shoe GetShoePorId(int shoeId);
        IEnumerable<IGrouping<int, Shoe>> GetShoesPorMarcaEntreRangoPrecios(decimal rangoMin, decimal rangoMax);
        IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadosPorGenre();
        IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadosPorSport();
        bool ExisteRelacion(Shoe shoe, Size size);
        void AsignarSizeAShoe(Shoe shoe, Size size);
        List<ShoeDto> GetListaDto();
        IEnumerable<ShoeDto> GetShoesFiltradosPorBrandYColour(int brandId, int colourId);
    }
}
