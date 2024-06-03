using MembershipsDemo.Interfaces;
using MembershipsDemo.Models;

namespace MembershipsDemo.LiteDb
{
    public class PartnerService : IPartner
    {
        private string tableName = "partners";
        private List<Partner> _partners;

        public List<Partner> All => _partners;

        public Task<bool> AddAsync(Partner model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int _id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Partner>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Partner> FindByIdAsync(int _id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Partner model)
        {
            throw new NotImplementedException();
        }
    }
}
