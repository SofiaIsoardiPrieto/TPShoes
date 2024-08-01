using TPShoes.Datos;
using TPShoes.Datos.Interfaces;
using TPShoes.Entidades.Clases;
using TPShoes.Servicios.Interfaces;

namespace TPShoes.Servicios.Servicios
{
    public class SportsServicio : ISportsServicio
    {
        private readonly IRepositorioSports _repository;
        private readonly IUnitOfWork _unitOfWork;
        public SportsServicio(IRepositorioSports repository, IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork;
        }
        public void Borrar(Sport sport)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _repository.Borrar(sport);
                _unitOfWork.SaveChanges();
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public bool EstaRelacionado(Sport sport)
        {
            return _repository.EstaRelacionado(sport);
        }

        public bool Existe(Sport sport)
        {
            return _repository.Existe(sport);
        }

        public Sport GetSportPorNombre(string sportNombre)
        {
            return _repository.GetSportPorNombre(sportNombre);
        }
        public int GetCantidad()
        {
            return _repository.GetCantidad();
        }
        public List<Sport> GetLista()
        {
            return _repository.GetLista();
        }

        public void Guardar(Sport sport)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                if (sport.SportId == 0)
                {
                    _repository.Agregar(sport);
                    _unitOfWork.SaveChanges();
                }
                else
                {
                    _repository.Editar(sport);
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

        public Sport? GetSportPorId(int sportId)
        {
            return _repository.GetSportPorId(sportId);
        }
    }

}
