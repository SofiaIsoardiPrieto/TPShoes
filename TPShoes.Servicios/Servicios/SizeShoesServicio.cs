using System.Drawing;
using TPShoes.Datos;
using TPShoes.Datos.Interfaces;
using TPShoes.Entidades.Clases;
using TPShoes.Entidades.Dtos;
using TPShoes.Servicios.Interfaces;

namespace TPShoes.Servicios.Servicios
{
    public class SizeShoesServicio : ISizeShoesServicio
    {

        private readonly IRepositorioSizeShoes _repository;
        private readonly IUnitOfWork _unitOfWork;

        public SizeShoesServicio(IRepositorioSizeShoes repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork;
        }

        public void Borrar(SizeShoe sizeShoe)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _repository.Borrar(sizeShoe);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public void Borrar(Entidades.Clases.Size size)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(SizeShoe sizeShoe)
        {
            try
            {
                return _repository.EstaRelacionado(sizeShoe);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(Entidades.Clases.Size size)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Entidades.Clases.Size size)
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

        public bool Existe(SizeShoe sizeShoeEditado)
        {
            throw new NotImplementedException();
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

        public List<SizeShoeDto>? GetSizeShoeDtoPorId(int shoeId)
        {
            try
            {
                return _repository.GetSizeShoeDtoPorId(shoeId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SizeShoe? GetSizeShoePorId(int sizeShoeId)
        {
            try
            {
                return _repository.GetSizeShoePorId(sizeShoeId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Entidades.Clases.Size> GetSizesPorId(int shoeId, bool incluyeShoe = false)
        {
            try
            {
                return _repository.GetSizesPorId(shoeId, incluyeShoe);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Entidades.Clases.Size size)
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

        public void Guardar(SizeShoe sizeShoe)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                if (sizeShoe.SizeId == 0)
                {
                    if (!_repository.Existe(sizeShoe))
                    {
                        _repository.AgregarSizeShoe(sizeShoe);
                    }
                    else
                    {
                        throw new Exception("El sizeShoe ya existe.");
                    }
                }
                else
                {
                    _repository.Editar(sizeShoe);
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
