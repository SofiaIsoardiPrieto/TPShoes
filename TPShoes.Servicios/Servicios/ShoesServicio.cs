using TPShoes.Datos.Interfaces;
using TPShoes.Entidades.Clases;
using TPShoes.Servicios.Interfaces;

namespace TPShoes.Servicios.Servicios
{
    public class ShoesServicio : IShoesServicio
    {
        private readonly IRepositorioShoes _repository;
        public ShoesServicio(IRepositorioShoes repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void Borrar(int shoeId)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Shoe shoe)
        {
            return _repository.Existe( shoe);
        }

        public int GetCantidad(Func<Shoe, bool>? filtro = null)
        {
            return _repository.GetCantidad(filtro);
        }

        public List<Shoe> GetLista()
        {
            return _repository.GetLista();
        }

        public List<Shoe> GetListaPaginadaOrdenadaFiltrada(int page, int pageSize)
        {
            return _repository.GetListaPaginadaOrdenadaFiltrada(page, pageSize);
        }

        public Shoe GetShoePorId(int shoeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadosPorColourYBrand()
        {
            return _repository.GetShoesAgrupadosPorColourYBrand();
        }

        public IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadosPorGenre()
        {
            return _repository.GetShoesAgrupadosPorGenre();
        }

        public IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadosPorSport()
        {
            return _repository.GetShoesAgrupadosPorSport();
        }

        public void Guardar(Shoe shoe)
        {
             _repository.Guardar(shoe);
        }
    }

}
