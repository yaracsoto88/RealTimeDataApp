using RealTimeDataApp.Domain.Entities;
using RealTimeDataApp.Domain.Interfaces;
using RealTimeDataApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<DataModel?> GetDataModelByIdAsync(int id)
        {
            return await _context.DataModels.FindAsync(id);
        }

        public async Task UpdateDataModelAsync(DataModel dataModel)
        {
            _context.DataModels.Update(dataModel);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataModel>> GetAllDataModelsAsync()
        {
            return await _context.DataModels.ToListAsync();
        }
    }
}
