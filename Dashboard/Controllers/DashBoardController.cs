﻿using Dashboard.Models;
using Dashboard.Models.Static;
using javax.jws;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllStation(string station)
        {
            List<StationModelDash> stations = new List<StationModelDash>();
            var client = new RestClient("http://18.219.131.199:1026/v2/entities");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("fiware-service", "helixiot");
            request.AddHeader("fiware-servicepath", "/");
            IRestResponse<List<Station>> response = client.Execute<List<Station>>(request);
            foreach (var dados in response.Data)
            {
                List<StationModel> teste = new List<StationModel>();
                var clientDados = new RestClient(string.Format("https://localhost:44397/api/StateSensors/{0}/{1}", dados.id.Replace("urn:ngsi-ld:", "") + "_station", station));
                client.Timeout = -1;
                var requestDados = new RestRequest(Method.GET);
                requestDados.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im1hcmN1cyIsInJvbGUiOiJtYXN0ZXJ1c2VyIiwibmJmIjoxNjIwODcwMDc4LCJleHAiOjE2MjA4NzcyNzgsImlhdCI6MTYyMDg3MDA3OH0.r0QiM1FtO3nwwCKqClPox-72laDsyDTLSFZCWj6P-O4");
                IRestResponse<List<StationModel>> responseDados = clientDados.Execute<List<StationModel>>(requestDados);
                teste.AddRange(responseDados.Data);
                stations.Add(new StationModelDash() { Station = dados.id.Replace("urn:ngsi-ld:", ""), SationModel = teste });
            }
            return Json(stations);
        }
        public string GetStation(string station)
        {
            StationModelDash dash = new StationModelDash();
            var clientDados = new RestClient(string.Format("https://localhost:44397/api/StateSensors/{0}/{1}", "station:005_station", station));
            clientDados.Timeout = -1;
            var requestDados = new RestRequest(Method.GET);
            requestDados.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im1hcmN1cyIsInJvbGUiOiJtYXN0ZXJ1c2VyIiwibmJmIjoxNjIwODcwMDc4LCJleHAiOjE2MjA4NzcyNzgsImlhdCI6MTYyMDg3MDA3OH0.r0QiM1FtO3nwwCKqClPox-72laDsyDTLSFZCWj6P-O4");
            IRestResponse<List<StationModel>> responseDados = clientDados.Execute<List<StationModel>>(requestDados);
            dash.Station = "station:003";
            dash.SationModel = responseDados.Data;
            return Newtonsoft.Json.JsonConvert.SerializeObject(dash);

        }
        [WebMethod]
        public string GetChartData(string station)
        {
            StationModelDash dash = new StationModelDash();
            var clientDados = new RestClient(string.Format("https://localhost:44397/api/StateSensors/{0}/{1}", "station:005_station", station));
            clientDados.Timeout = -1;
            var requestDados = new RestRequest(Method.GET);
            requestDados.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im1hcmN1cyIsInJvbGUiOiJtYXN0ZXJ1c2VyIiwibmJmIjoxNjIwODcwMDc4LCJleHAiOjE2MjA4NzcyNzgsImlhdCI6MTYyMDg3MDA3OH0.r0QiM1FtO3nwwCKqClPox-72laDsyDTLSFZCWj6P-O4");
            IRestResponse<List<StationModel>> responseDados = clientDados.Execute<List<StationModel>>(requestDados);
            dash.Station = "station:003";
            dash.SationModel = responseDados.Data;

            var chartData = new object[dash.SationModel.Count + 1];
            chartData[0] = new object[]{
                "Minutes",
                "station:003"
            };
            List<RetornoTeste> list = new List<RetornoTeste>();
            int j = 0;
            foreach (var i in responseDados.Data)
            {
                j++;
                RetornoTeste teste = new RetornoTeste();
                teste.minutes = j;
                teste.value = Convert.ToInt32(i.attrValue);
                list.Add(teste);
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(list);
        }
        public List<StationModel> ListModel(List<StationModel> data, string sensor)
        {
            List<StationModel> models = new List<StationModel>();
            TimeSpan time = new TimeSpan();
            DateTime LastDate = new DateTime();
            foreach (var model in data.Where(x => x.attrName == sensor && x.recvTime.Day == 13).OrderBy(x => x.recvTime).ToList())
            {
                if (LastDate.Year == 1)
                {
                    LastDate = model.recvTime;
                    models.Add(model);
                }
                time = model.recvTime - LastDate;
                if (time.TotalMinutes >= 5)
                {
                    LastDate = model.recvTime;
                    models.Add(model);
                }
            }
            return models;
        }
        public IActionResult StationDash()
        {
            List<StationModel> models = new List<StationModel>();
            var client = new RestClient("https://localhost:44397/api/StateSensors/GetStation/station:007_station");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im1hcmN1cyIsInJvbGUiOiJtYXN0ZXJ1c2VyIiwibmJmIjoxNjIwODcwMDc4LCJleHAiOjE2MjA4NzcyNzgsImlhdCI6MTYyMDg3MDA3OH0.r0QiM1FtO3nwwCKqClPox-72laDsyDTLSFZCWj6P-O4");
            IRestResponse<List<StationModel>> response = client.Execute<List<StationModel>>(request);
            foreach(string sensor in StaticSensor.sensor)
            {
                models.AddRange(ListModel(response.Data, sensor));
            }
            return View(models);
        }
    }
}