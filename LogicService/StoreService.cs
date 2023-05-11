using Microsoft.Extensions.Caching.Memory;

namespace LogicService;
public interface IStoreService
{
    public T? GetItem<T>(int id);
    public void AddItem<T>(T item, int id);
    public List<T>? GetItems<T>();
    public void AddItems<T>(List<T> items);
}

public class StoreService : IStoreService
{
    private MemoryCache cache = new MemoryCache(new MemoryCacheOptions());

    public StoreService(){}

    public T? GetItem<T>(int id)
        => cache.Get<T>($"{typeof(T).Name}-{id}");

    public void AddItem<T>(T item, int id)
        => cache.Set<T>($"{typeof(T).Name}-{id}", item);

    public void AddItems<T>(List<T> items)
        => cache.Set<List<T>>($"{typeof(T).Name}", items);

    public List<T>? GetItems<T>()
        => cache.Get<List<T>>(typeof(T).Name);
}