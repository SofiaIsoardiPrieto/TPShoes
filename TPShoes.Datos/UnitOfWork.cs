﻿using Microsoft.EntityFrameworkCore.Storage;

namespace TPShoes.Datos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContextShoes _context;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(DBContextShoes context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
                _transaction?.Commit();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            _transaction?.Rollback();
        }

        public int SaveChanges()
        {
            try
            {

                return _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }

}
