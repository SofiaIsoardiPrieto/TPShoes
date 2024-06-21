using TPShoes.Datos;
using TPShoes.Datos.Interfaces;
using TPShoes.Entidades.Clases;
using TPShoes.Servicios.Interfaces;

namespace TPShoes.Servicios.Servicios
{
    public class ColoursServicio : IColoursServicio
    {

        private readonly IRepositorioColours _repository;
        private readonly IUnitOfWork _unitOfWork;
        public ColoursServicio(IRepositorioColours repository, IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork;
        }
        public void Borrar(Colour colour)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _repository.Borrar(colour);
                _unitOfWork.SaveChanges();
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public bool EstaRelacionado(Colour colour)
        {
            return _repository.EstaRelacionado(colour);
        }

        public bool Existe(Colour colour)
        {
            return _repository.Existe(colour);
        }

        public Colour? GetColourPorId(int colourId)
        {
            return _repository.GetColourPorId(colourId);
        }

        public Colour GetColourPorNombre(string colourNombre)
        {
            return _repository.GetColourPorNombre(colourNombre);
        }

        public List<Colour> GetLista()
        {
            return _repository.GetLista();
        }

        public void Guardar(Colour colour)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                if (colour.ColourId == 0)
                {
                    _repository.Agregar(colour);
                    _unitOfWork.SaveChanges();
                }
                else
                {
                    _repository.Editar(colour);
                    _unitOfWork.SaveChanges();
                }
                _unitOfWork.SaveChanges();
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }

        }
    }

}
