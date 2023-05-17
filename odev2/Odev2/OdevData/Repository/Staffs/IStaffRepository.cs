using OdevData.Repository.Base;
using OdevData.Domain;


namespace OdevData.Repository.Staffs
{
    public interface IStaffRepository : IGenericRepository<Staff>
    {
        List<Staff> GetStaffsByCriteria(string firstName);
    }
}
