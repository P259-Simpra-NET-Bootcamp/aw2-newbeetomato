using OdevData.Domain;
using OdevData.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdevData.UnitOfWork;

    public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Staff> StaffRepository { get; }

    void Complete();
    void CompleteWithTransaction();
}

