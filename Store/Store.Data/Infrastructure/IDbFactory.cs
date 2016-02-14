namespace Store.Data.Infrastructure
{
    public interface IDbFactory
    {
        StoreEntities Init();
    }
}
