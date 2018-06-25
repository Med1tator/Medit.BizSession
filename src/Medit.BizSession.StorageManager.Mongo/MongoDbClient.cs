using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.BizSession.StorageManager.Impl
{
    internal class MongoDbClient
    {
        private MongoDatabase _mongodb;
        private readonly string tableName = "T_BizSession";

        public MongoDbClient()
        {
            InitMongoDb();
        }

        private void InitMongoDb()
        {
            string dbConn = ConfigurationManager.AppSettings["MongoDbConn"];
            string dbName = ConfigurationManager.AppSettings["MongoDbName"];

            if (string.IsNullOrEmpty(dbConn))
                throw new Exception("读取Mongo服务配置项【MongoDbConn】失败！");
            if (string.IsNullOrEmpty(dbName))
                throw new Exception("读取Mongo服务配置项【MongoDbName】失败！");

            _mongodb = new MongoClient(dbConn).GetServer().GetDatabase(dbName);
        }

        public bool Set(string id, string jsonData)
        {
            try
            {
                MongoCollection<BsonDocument> collection = _mongodb.GetCollection(tableName);

                BsonDocument data = new BsonDocument();
                data.Add("Id", id);
                data.Add("SessionData", jsonData);
                data.Add("EntryDate", DateTime.Now);

                collection.Insert(data);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Get(string id)
        {
            try
            {
                MongoCollection<BsonDocument> collection = _mongodb.GetCollection(tableName);
                var query = Query.EQ("Id", id);

                BsonDocument data = collection.Find(query).FirstOrDefault();
                if (data == null)
                    return string.Empty;

                return data["SessionData"].AsString;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(string id)
        {
            try
            {
                MongoCollection<BsonDocument> collection = _mongodb.GetCollection(tableName);
                var query = Query.EQ("Id", id);
                collection.Remove(query);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool RemoveBefore(DateTime dateLimit)
        {
            try
            {
                MongoCollection<BsonDocument> collection = _mongodb.GetCollection(tableName);
                var query = Query.LTE("EntryDate", dateLimit);
                collection.Remove(query);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
