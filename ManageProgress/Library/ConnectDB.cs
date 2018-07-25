using ManageProgress.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ManageProgress.Library
{
    public class ConnectDB
    {
        private string _connectString;

        public ConnectDB(string dbName)
        {
            _connectString = ConfigurationManager.ConnectionStrings[dbName].ConnectionString;
        }

        public List<ProgressModel> GetAllProgresses()
        {
            List<ProgressModel> result = new List<ProgressModel>();
            using (var conn = new SqlConnection(_connectString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = @"SELECT * From Progresses";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ProgressModel
                        {
                            Id = (int)reader["Id"],
                            Title = (string)reader["Title"],
                            UserId = (string)reader["UserId"],
                            DateTimeRegistered = (DateTime)reader["DateTime_Registered"],
                            NumberOfItems = (int)reader["Number_Of_Items"]
                        });
                    }
                }
            }
            return result;
        }
        // TODO: GETProgress(loginId) ログイン中のユーザの進捗のみを表示するメソッドを作る


        public bool SetProgressAndTasks(ProgressModel progress, List<TaskModel> tasks)
        {
            try
            {
                using (var conn = new SqlConnection(_connectString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    using (var sqlTran = conn.BeginTransaction())
                    {
                        cmd.Transaction = sqlTran;
                        cmd.CommandText = @"
INSERT 
INTO Progresses 
VALUES
    (@UserId, 
    @Title, 
    @DateTime_Registered,
    @Number_Of_Items, 
    @Password);";

                        cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.NVarChar, 50)).Value = progress.UserId;
                        cmd.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 50)).Value = progress.Title;
                        cmd.Parameters.Add(new SqlParameter("@DateTime_Registered", SqlDbType.DateTime)).Value = progress.DateTimeRegistered;
                        cmd.Parameters.Add(new SqlParameter("@Number_Of_items", SqlDbType.Int)).Value = progress.NumberOfItems;
                        cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 50)).Value = progress.Password;
                        cmd.ExecuteNonQuery();
                        
                        foreach (var task in tasks)
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandText = @"
INSERT
INTO Tasks
VALUES
    (@ProgressId,
    @Task)";

                            cmd.Parameters.Add(new SqlParameter("@ProgressId", SqlDbType.Int)).Value = task.ProgressId;
                            cmd.Parameters.Add(new SqlParameter("@Task", SqlDbType.Int)).Value = task.Task;
                            cmd.ExecuteNonQuery();
                        }

                        sqlTran.Commit();
                    }
                }
            }
            catch
            {

                return false;
            }
            return true;
        }
    }
}