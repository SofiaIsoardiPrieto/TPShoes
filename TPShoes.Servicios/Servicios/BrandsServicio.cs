using TPShoes.Datos;
using TPShoes.Datos.Interfaces;
using TPShoes.Entidades;
using TPShoes.Servicios.Interfaces;

namespace TPShoes.Servicios.Servicios
{
    public class BrandsServicio : IBrandsServicio
    {
        private readonly IRepositorioBrands _repository;
        private readonly IUnitOfWork _unitOfWork;
        public BrandsServicio(IRepositorioBrands repository, IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork;
        }


        public void Borrar(Brand brand)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _repository.Borrar(brand);
                _unitOfWork.SaveChanges();
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }


        }
        public bool EstaRelacionado(Brand brand)
        {
            return _repository.EstaRelacionado(brand);
        }

        public bool Existe(Brand brand)
        {
            return _repository.Existe(brand);
        }

        public Brand? GetBrandPorId(int brandId)
        {
            return _repository.GetBrandPorId(brandId);
        }

        public Brand GetBrandPorNombre(string brandNombre)
        {
            return _repository.GetBrandPorNombre(brandNombre);
        }

        public int GetCantidad()
        {
            return _repository.GetCantidad();
        }

        public List<Brand> GetLista()
        {
            return _repository.GetLista();
        }

        public void Guardar(Brand brand)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                if (brand.BrandId == 0)
                {
                    _repository.Agregar(brand);
                    _unitOfWork.SaveChanges();
                }
                else
                {
                    _repository.Editar(brand);
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
