using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca_MongoDB.Entity;
using MongoDB.Driver;

namespace Biblioteca_MongoDB.Data
{
    public class Repository<TEntity>
    {
        private readonly MongoDbContext _mongoDb;
        IMongoCollection<TEntity> _mongoCollection;

        public Repository(MongoDbContext mongoDb)
        {
            _mongoDb = mongoDb;
            _mongoCollection = _mongoDb.DB.GetCollection<TEntity>(typeof(TEntity).Name.ToLower());
        }

        public void Insert(TEntity obj)
        {
            _mongoCollection.InsertOne(obj);
        }

        public void Update(FilterDefinition<TEntity> p, TEntity obj)
        {
            _mongoCollection.FindOneAndReplace<TEntity>(p, obj);
        }

        public void Delete(FilterDefinition<TEntity> p)
        {
            _mongoCollection.DeleteOne(p);
        }

        public TEntity Select(FilterDefinition<TEntity> p)
        {
            return _mongoCollection.Find<TEntity>(p).FirstOrDefault();
        }

        public IList<TEntity> SelectAll(FilterDefinition<TEntity> p)
        {
            return _mongoCollection.Find(p).ToList<TEntity>();
        }
    }
}
