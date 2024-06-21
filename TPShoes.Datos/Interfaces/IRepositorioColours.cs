using TPShoes.Entidades.Clases;

namespace TPShoes.Datos.Interfaces
{
    public interface IRepositorioColours
    {
        void Agregar(Colour colour);
        void Borrar(Colour colour);
        void Editar(Colour colour);
        bool EstaRelacionado(Colour colour);
        bool Existe(Colour colour);
        Colour? GetColourPorId(int colourId);
        Colour GetColourPorNombre(string colourNombre);
        List<Colour> GetLista();
        void SaveChanges();

    }

}
