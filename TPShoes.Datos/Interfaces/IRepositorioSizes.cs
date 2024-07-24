using TPShoes.Entidades.Clases;
using TPShoes.Entidades.Enum;
using Size = TPShoes.Entidades.Clases.Size;

namespace TPShoes.Datos.Interfaces
{
    public interface IRepositorioSizes
    {

        void Agregar(Size size);
        void AgregarSizeShoe(SizeShoe nuevaRelacion);
        void Borrar(Size size);
        void Editar(Size size);
        bool Existe(Size size);
        List<Size> GetLista();
        Size? GetSizesPorId(int id, bool incluyeShoe = false);

        int GetCantidad();
        List<Size> GetSizesPaginadosOrdenados(int page, int pageSize, Orden? orden = null);
        bool EstaRelacionado(Size size);
    }
}
