using Dashboard.Models.Static;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public class User
    {
        [Required]
        public string username { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]

        public string password { get; set; }
        public string Token { get; set; }

        public bool Login(User user)
        {
            return (Response(user).StatusCode == System.Net.HttpStatusCode.OK)?true:false;
        }
        public string GetToken(User user)
        {
            return Response(user).Data.Token;
        }
        private IRestResponse<User> Response(User user)
        {
            var client = new RestClient(string.Concat(EndPoint.Public,"Auth"));
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("accept", "*/*");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonSerializer.Serialize(user), ParameterType.RequestBody);
            return client.Execute<User>(request);

        }
    }
}
