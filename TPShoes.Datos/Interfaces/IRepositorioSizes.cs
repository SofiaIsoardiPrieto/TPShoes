using TPShoes.Entidades.Clases;
using TPShoes.Entidades.Dtos;
using TPShoes.Entidades.Enum;
using Size = TPShoes.Entidades.Clases.Size;

namespace TPShoes.Datos.Interfaces
{
    public interface IRepositorioSizes
    {

        void Agregar(Size size);
        void AgregarSizeShoe(SizeShoe sizeShoe);
        void Borrar(Size size);
        void Editar(Size size);
        bool Existe(SizeShoe sizeShoe);
        void Borrar(SizeShoe sizeShoe);
        void Editar(SizeShoe sizeShoe);
        bool Existe(Size size);
        //  List<Size> GetLista();
        List<Size> GetSizesPorId(int shoeId, bool incluyeShoe = false);

      //  int GetCantidad();
      //  List<Size> GetSizesPaginadosOrdenados(int page, int pageSize, Orden? orden = null);
        bool EstaRelacionado(Size size);
        bool EstaRelacionado(SizeShoe size);
        int GetCantidad();
        List<SizeShoeDto>? GetSizeShoeDtoPorId(int shoeId);
        SizeShoe? GetSizeShoePorId(int sizeShoeId);
    }
}
