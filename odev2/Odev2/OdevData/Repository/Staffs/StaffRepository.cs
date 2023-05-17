using Microsoft.EntityFrameworkCore;
using OdevData.Context;
using OdevData.Domain;
using OdevData.Repository.Base;
using System;
using Microsoft.EntityFrameworkCore;
using OdevData.Context;
using OdevData.Domain;
using OdevData.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdevData.Repository.Staffs
{
    public class StaffRepository : GenericRepository<Staff>,IStaffRepository
    {
        public StaffRepository(Odev2DbContext context) : base(context)
        {
        }

        public List<Staff> GetStaffsByCriteria(string firstName)
        {
            return Where(x => x.FirstName == firstName);
        }
    }
}
