using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MVC_API_CONNECTIVITY.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace MVC_API_CONNECTIVITY.Controllers
{
    public class UserController : ApiController
    {

        [HttpPost]
        public string PostUserDetails(UserModel um)
        {
            
            //Connect to MongoDB
            var connectionString = "mongodb://localhost";
            MongoClient client = new MongoClient(connectionString);
            MongoServer objServer = client.GetServer();

            //MongoServer objServer = MongoServer.Create("Server=localhost:27017");
            //Provide a database name(Mongo server will automatically check a
            //database with this name while inserting.
            //if exist then ok otherwise it will  automatically create a database)
            MongoDatabase objDatabse = objServer.GetDatabase("MVCTestDB");
            //Provide a table Name(Mongo will create a table with this name.
            //if its already exist then mongo will insert in this table otherwise
            //it will create a table with this name and then Mongo will insert)
            MongoCollection<BsonDocument> UserDetails = objDatabse.GetCollection<BsonDocument>("Users");
            //Insert into Users table.
            UserDetails.Insert<UserModel>(um);
            //return View();
            return "Successful";
        }
    }

   
}
