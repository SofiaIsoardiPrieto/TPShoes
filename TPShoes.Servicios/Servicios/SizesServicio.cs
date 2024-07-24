using TPShoes.Datos;
using TPShoes.Datos.Interfaces;
using TPShoes.Entidades.Clases;
using TPShoes.Entidades.Enum;
using TPShoes.Servicios.Interfaces;

namespace TPShoes.Servicios.Servicios
{
    public class SizesServicio : ISizesServicio
    {

        private readonly IRepositorioSizes _repository;
        private readonly IUnitOfWork _unitOfWork;

        public SizesServicio(IRepositorioSizes repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork;
        }

        public void Borrar(Size size)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _repository.Borrar(size);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public bool EstaRelacionado(Size size)
        {
            try
            {
                return _repository.EstaRelacionado(size);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Size size)
        {
            try
            {
                return _repository.Existe(size);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad()
        {
            try
            {
                return _repository.GetCantidad();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Size> GetLista()
        {
            try
            {
                return _repository.GetLista();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Size> GetSizesPaginadosOrdenados(int page, int pageSize, Orden? orden = null)
        {
            try
            {
                return _repository.GetSizesPaginadosOrdenados(page, pageSize, orden);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Size? GetSizesPorId(int id, bool incluyeShoe = false)
        {
            try
            {
                return _repository.GetSizesPorId(id, incluyeShoe);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Size size)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                if (size.SizeId == 0)
                {
                    if (!_repository.Existe(size))
                    {
                        _repository.Agregar(size);
                    }
                    else
                    {
                        throw new Exception("El Size ya existe.");
                    }
                }
                else
                {
                    _repository.Editar(size);
                }
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
