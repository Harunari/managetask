﻿using ManageProgress.Library;
using Newtonsoft.Json;
using System;
using System.Web.Services;

namespace ManageProgress.API
{
    public partial class GetJsonString : APIPage
    {
        [WebMethod]
        public static string GetRegisteredProgresses(string userId)
        {
            try
            {
                var cdb = new ConnectDB("Database1");
                var result = cdb.GetAProgress(userId);
                if (result.Count == 0)
                {
                    return "nil";
                }
                // シリアライズ
                string json = JsonConvert.SerializeObject(result, Formatting.Indented);
                return json;
            }
            catch (Exception ex)
            {
                var thisPage = new GetJsonString();
                thisPage.WriteErrorLog(ex.Message);
                return "error";
                
            }
        }
        [WebMethod]
        public static string GetParticipants(string strProgressId)
        {
            var cdb = new ConnectDB("Database1");
            try
            {
                int progressId = int.Parse(strProgressId);
                var result = cdb.GetParticipants(progressId);
                string json = JsonConvert.SerializeObject(result, Formatting.Indented);
                return json;
            }
            catch (Exception ex)
            {
                var thisPage = new GetJsonString();
                thisPage.WriteErrorLog(ex.Message);
                return "error";
            }
        }
        [WebMethod]
        public static string GetTasks(string strProgressId)
        {
            var cdb = new ConnectDB("Database1");
            try
            {
                int progressId = int.Parse(strProgressId);
                var result = cdb.GetTasks(progressId);
                string json = JsonConvert.SerializeObject(result, Formatting.Indented);
                return json;
            }
            catch (Exception ex)
            {
                var thisPage = new GetJsonString();
                thisPage.WriteErrorLog(ex.Message);
                return "error";
            }
        }

    }
}