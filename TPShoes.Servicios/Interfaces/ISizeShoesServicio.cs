using TPShoes.Entidades.Clases;
using TPShoes.Entidades.Dtos;
using TPShoes.Entidades.Enum;

namespace TPShoes.Servicios.Interfaces
{
    public interface ISizeShoesServicio 
    { 
        void Guardar(Size size);
        void Guardar(SizeShoe sizeShoe);
        void Borrar(Size size);
        bool Existe(Size size);
        List<Size> GetSizesPorId(int id, bool incluyeShoe = false);
       // int GetCantidad();
        bool EstaRelacionado(Size size);
        List<SizeShoeDto>? GetSizeShoeDtoPorId(int shoeId);
        SizeShoe? GetSizeShoePorId(int sizeShoeId);
        bool Existe(SizeShoe sizeShoeEditado);
    }
}
