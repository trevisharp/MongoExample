using MongoDB.Driver;

public class MongoService
{
    MongoClient client;
    IMongoDatabase db;

    public MongoService(string connectionString, string database)
    {
        var settings = MongoClientSettings
            .FromConnectionString(connectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        this.client = new MongoClient(settings);
        this.db = this.client.GetDatabase(database);
    }

    public IMongoCollection<T> GetCollection<T>()
        => this.db.GetCollection<T>(typeof(T).Name);
}