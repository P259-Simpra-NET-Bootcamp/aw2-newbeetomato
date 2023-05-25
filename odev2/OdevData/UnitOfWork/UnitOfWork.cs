using Microsoft.EntityFrameworkCore;
using OdevData.Context;
using OdevData.Domain;
using OdevData.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdevData.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Staff> StaffRepository { get; set; }

        private readonly Odev2DbContext _db;
        private bool disposed;
        public UnitOfWork(Odev2DbContext dbContext)
        {
            _db = dbContext;
            StaffRepository = new GenericRepository<Staff>(dbContext);
        }

        public void Complete()
        {
            _db.SaveChanges();
        }

        public void CompleteWithTransaction()
        {
            using (var dbDcontextTransaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.SaveChanges();
                    dbDcontextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    // logging
                    dbDcontextTransaction.Rollback();
                }
            }
        }
        private void Clean(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }

            disposed = true;
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            Clean(true);
        }

    }
}
