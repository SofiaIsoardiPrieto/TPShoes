using TPShoes.Entidades.Clases;
using TPShoes.Entidades.Enum;

namespace TPShoes.Servicios.Interfaces
{
    public interface ISizesServicio
    {
        void Guardar(Size size);
        void Borrar(Size size);
        bool Existe(Size size);
        List<Size> GetLista();
        Size? GetSizesPorId(int id, bool incluyeShoe = false);

        int GetCantidad();
        List<Size> GetSizesPaginadosOrdenados(int page, int pageSize, Orden? orden = null);

        bool EstaRelacionado(Size size);
    }
}
