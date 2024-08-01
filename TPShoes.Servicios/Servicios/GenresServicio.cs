using TPShoes.Datos;
using TPShoes.Datos.Interfaces;
using TPShoes.Entidades.Clases;
using TPShoes.Servicios.Interfaces;

namespace TPShoes.Servicios.Servicios
{
    public class GenresServicio : IGenresServicio
    {
        private readonly IRepositorioGenres _repository;
        private readonly IUnitOfWork _unitOfWork;
        public GenresServicio(IRepositorioGenres repository, IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork;
        }
        public void Borrar(Genre genre)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _repository.Borrar(genre);
                _unitOfWork.SaveChanges();
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();

                throw;
            }
        }

        public bool EstaRelacionado(Genre genre)
        {
            return _repository.EstaRelacionado(genre);
        }

        public bool Existe(Genre genre)
        {
            return _repository.Existe(genre);
        }
        public int GetCantidad()
        {
            return _repository.GetCantidad();
        }
        public Genre? GetGenrePorId(int genreId)
        {
            return _repository.GetGenrePorId(genreId);
        }

        public Genre GetGenrePorNombre(string genreNombre)
        {
            return _repository.GetGenrePorNombre(genreNombre);
        }

        public List<Genre> GetLista()
        {
            return _repository.GetLista();
        }

        public void Guardar(Genre genre)
        {

            try
            {
                _unitOfWork.BeginTransaction();
                if (genre.GenreId == 0)
                {
                    _repository.Agregar(genre);
                    _unitOfWork.SaveChanges();
                }
                else
                {
                    _repository.Editar(genre);
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
