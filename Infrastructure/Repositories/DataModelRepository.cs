using RealTimeDataApp.Domain.Entities;
using RealTimeDataApp.Domain.Interfaces;
using RealTimeDataApp.Infrastructure.Data;

namespace RealTimeDataApp.Infrastructure.Repositories
{
    public class DataModelRepository : IDataModelRepository
    {
        private readonly AppDbContext _context;

        public DataModelRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddDataModelAsync(DataModel dataModel)
        {
            _context.DataModels.Add(dataModel);
            await _context.SaveChangesAsync();
        }
        public async Task <IEnumerable<DataModel>> GetAllDataModelsAsync(){
            
            return null;
        }
    }   
}