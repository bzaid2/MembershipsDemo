using LiteDB;
using MembershipsDemo.Interfaces;
using MembershipsDemo.Models;

namespace MembershipsDemo.LiteDb
{
    public class PartnerService : IPartner
    {
        private string tableName = "partners";
        private List<Partner> _partners;
        private const string UserName = "Admin"; // TODO: Cambiar por usuario autenticado

        public List<Partner> All => _partners;

        public async Task<bool> AddAsync(Partner model)
        {
            model.CreatedAt = DateTime.Now;
            model.CreatedBy = UserName;
            model.UpdatedAt = DateTime.Now;
            model.UpdatedBy = UserName;
            using (var db = new LiteDatabase(LocalData.fileDb))
            {
                return await Task.Run(() =>
                {
                    var col = db.GetCollection<Partner>(tableName);
                    col.Insert(model);
                    return model.Id.ToString().Length > 0;
                });
            }
        }

        public async Task<bool> DeleteAsync(int _id)
        {
            using (var db = new LiteDatabase(LocalData.fileDb))
            {
                return await Task.Run(() =>
                {
                    var col = db.GetCollection<Partner>(tableName);
                    return col.Delete(_id);
                });
            }
        }

        public async Task<List<Partner>> FindAllAsync()
        {
            using (var db = new LiteDatabase(LocalData.fileDb))
            {
                return await Task.Run(() =>
                {
                    var col = db.GetCollection<Partner>(tableName);
                    _partners = col.FindAll().ToList();
                    return _partners;
                });
            }
        }

        public async Task<Partner> FindByIdAsync(int _id)
        {
            using (var db = new LiteDatabase(LocalData.fileDb))
            {
                return await Task.Run(() =>
                {
                    var col = db.GetCollection<Partner>(tableName);
                    return col.FindById(_id);
                });
            }
        }

        public async Task<bool> UpdateAsync(Partner model)
        {
            model.UpdatedAt = DateTime.Now;
            model.UpdatedBy = UserName;
            using (var db = new LiteDatabase(LocalData.fileDb))
            {
                return await Task.Run(() =>
                {
                    var col = db.GetCollection<Partner>(tableName);
                    return col.Update(model);
                });
            }
        }
    }
}
