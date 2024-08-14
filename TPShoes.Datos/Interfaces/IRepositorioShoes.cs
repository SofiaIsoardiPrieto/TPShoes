using System.Linq.Expressions;
using TPShoes.Entidades;
using TPShoes.Entidades.Clases;
using TPShoes.Entidades.Dtos;
using TPShoes.Entidades.Enum;

namespace TPShoes.Datos.Interfaces
{
    public interface IRepositorioShoes
    {
        bool Existe(Shoe shoe);
       int GetCantidad(Expression<Func<Shoe, bool>>? filtro = null);
        List<Shoe> GetLista();
        List<ShoeDto> GetListaPaginadaOrdenadaFiltrada(int  registrosPorPagina,
            int paginaActual, Orden? orden = null, Brand? BrandFiltro = null,
            Colour? ColourFiltro = null, Expression<Func<Shoe, bool>>? rangoPrecio = null);
      
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
        IEnumerable<IGrouping<int, Shoe>> GetShoesPorMarcaEntreRangoPrecios(decimal rangoMin, decimal rangoMax);
    }
}
