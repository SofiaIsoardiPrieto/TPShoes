using TPShoes.Entidades.Clases;
using TPShoes.Entidades.Dtos;
using TPShoes.Entidades.Enum;

namespace TPShoes.Servicios.Interfaces
{
    public interface ISizeShoesServicio 
    { 
        void Guardar(Size size);
        void Guardar(SizeShoe sizeShoe);
        bool Existe(Size size);
        List<Size> GetSizesPorId(int id, bool incluyeShoe = false);
       // int GetCantidad();
        bool EstaRelacionado(Size size);
        List<SizeShoeDto>? GetSizeShoeDtoPorId(int shoeId);
        SizeShoe? GetSizeShoePorId(int sizeShoeId);
        bool Existe(SizeShoe sizeShoeEditado);
        SizeShoe GetSizeShoePorId(int shoeId, int sizeId);
        void Borrar(SizeShoe sizeShoe);
        List<ShoeDto> GetListaShoeDtoPorSize(int sizeIdSeleccionado);
       
    }
}
