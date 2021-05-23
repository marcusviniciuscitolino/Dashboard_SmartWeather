using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Models.Static
{
    public static class EndPoint
    {
        public static string Local = "https://localhost:44397/api/StateSensors";
        public static string ServerHelix = "http://18.219.131.199:1026/v2/entities";
        public static string Public = "https://smart-wheater-api.herokuapp.com/api/";
    }
}
