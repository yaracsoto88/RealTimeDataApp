using System.Collections.Concurrent;
using RealTimeDataApp.Domain.Entities;

namespace RealTimeDataApp.Infrastructure.Data
{
    public class InMemoryDataStore
{
    private readonly ConcurrentDictionary<int, DataModel> _dataModels = new ConcurrentDictionary<int, DataModel>();

    public void Add(DataModel dataModel)
    {
        _dataModels[dataModel.Id] = dataModel;
    }

    public DataModel GetById(int id)
    {
        _dataModels.TryGetValue(id, out var dataModel);
        return dataModel;
    }

    public IEnumerable<DataModel> GetAll()
    {
        return _dataModels.Values;
    }

    public void Update(DataModel dataModel)
    {
        _dataModels[dataModel.Id] = dataModel;
    }

    public bool Remove(int id)
    {
        return _dataModels.TryRemove(id, out _);
    }
}

}