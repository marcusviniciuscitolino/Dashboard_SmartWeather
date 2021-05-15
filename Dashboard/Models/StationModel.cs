using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public class StationModel
    {
        public FakeID _id { get; set; }
        public DateTime recvTime { get; set; }
        public string attrName { get; set; }
        public string attrType { get; set; }
        public string attrValue { get; set; }

    }
    public class StationModelDash
    {
        public string Station { get; set; }
        public List<StationModel> SationModel { get; set; }
    }
    public class RetornoTeste
    {
        public int minutes { get; set; }
        public int value { get; set; }
    }

    public class FakeID
    {
        public int timestamp { get; set; }
        public int machine { get; set; }
        public int pid { get; set; }
        public int increment { get; set; }
        public DateTime creationTime { get; set; }
    }
}
