using TPShoes.Entidades.Clases;

namespace TPShoes.Servicios.Interfaces
{
    public interface IColoursServicio
    {
        void Borrar(Colour colour);
        bool EstaRelacionado(Colour colour);
        bool Existe(Colour colour);
        Colour? GetColourPorId(int colourId);
        Colour GetColourPorNombre(string colourNombre);
        List<Colour> GetLista();
        void Guardar(Colour colour);
        int GetCantidad();

    }
}
