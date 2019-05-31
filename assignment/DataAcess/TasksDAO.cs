using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
using assignment.Models;
using System.Collections.Generic;

namespace assignment.DataAccess
{
    public class TasksDAO
    {
        static readonly string connectionStr = "server=localhost;port=3306;user id=root;password=ISEM551test;database=ISEM551";
        static readonly string retrieveTasksQuery = "select * from task";

        public TasksDAO()
        {
        }

        public static List<TaskVO> RetrieveTasks()
        {

            Console.WriteLine("=====> Starting Get Tasks DAO...");

            //string connectionStr = "server=localhost;port=3306;user id=root;password=ISEM551test;database=ISEM551";
            //string sqlQuery = "select * from task";

            var resultList = new List<TaskVO>();

            MySqlConnection mySqlConn = new MySqlConnection(connectionStr);
            MySqlCommand mySqlCmd = new MySqlCommand(retrieveTasksQuery, mySqlConn);

            DataTable dt = new DataTable();
            DataSet resultSet = new DataSet();

            mySqlConn.Open();
            MySqlDataReader mySqlDataReader = mySqlCmd.ExecuteReader();

            while(mySqlDataReader.Read())
            {
                resultList.Add(new TaskVO()
                {
                    tid = mySqlDataReader["task_id"].ToString(),
                    firstName = mySqlDataReader["first_name"].ToString(),
                    lastName = mySqlDataReader["last_name"].ToString(),
                    task = mySqlDataReader["task_name"].ToString(),
                    status = mySqlDataReader["Status"].ToString(),
                    iteration = mySqlDataReader["iteration"].ToString()
                });
            }

            dt.Load(mySqlDataReader);
            resultSet.Tables.Add(dt);

            mySqlDataReader.Close();
            mySqlCmd.Dispose();
            mySqlConn.Close();

            return resultList;
        }

        public static DataSet RetrieveTasks1()
        {

            Console.WriteLine("=====> Starting Get Tasks DAO1...");

            //string connectionStr = "server=localhost;port=3306;user id=root;password=ISEM551test;database=ISEM551";
            //string sqlQuery = "select * from task";

            MySqlConnection mySqlConn = new MySqlConnection(connectionStr);
            MySqlCommand mySqlCmd = new MySqlCommand(retrieveTasksQuery, mySqlConn);

            DataTable dt = new DataTable();
            DataSet resultSet = new DataSet();

            mySqlConn.Open();
            MySqlDataReader mySqlDataReader = mySqlCmd.ExecuteReader();
            dt.Load(mySqlDataReader);
            resultSet.Tables.Add(dt);

            mySqlDataReader.Close();
            mySqlCmd.Dispose();
            mySqlConn.Close();

            //Console.WriteLine("Getting Resultset: " + resultSet.Tables[0]);
            //Console.WriteLine("Getting Resultset: " + resultSet.Tables[1]);

            return resultSet;
        }

        public static DataSet RetrieveTasks2()
        {

            Console.WriteLine("=====> Starting Get Tasks DAO2...");


            SqlConnection conn;
            //string retrieveTasksQuery = "select * from task";
            SqlCommand sqlCommand;
            SqlDataReader sqlDataReader;


            DataTable dt = new DataTable();
            DataSet resultSet = new DataSet();

            string connStr = ConfigurationManager.ConnectionStrings["CONNECTION_STR_LOCAL"].ConnectionString;
            conn = new SqlConnection(connStr);

            conn.Open();
            sqlCommand = new SqlCommand(retrieveTasksQuery, conn);
            sqlDataReader = sqlCommand.ExecuteReader();
            dt.Load(sqlDataReader);
            resultSet.Tables.Add(dt);

            Console.WriteLine("Getting Resultset: " + resultSet);

            sqlDataReader.Close();
            sqlCommand.Dispose();
            conn.Close();

            return resultSet;
        }

        public static void UpdateTasks(List<TaskVO> taskList)
        {
            Console.WriteLine("=====> Starting Saving Tasks DAO...");

            MySqlConnection mySqlConn = new MySqlConnection(connectionStr);

            mySqlConn.Open();

            for (int i = 0; i < taskList.Count; i++)
            {
                TaskVO taskToUpdate = taskList[i];
                var updateTasksQuery = "UPDATE task SET first_name = @firstname, last_name = @lastname, task_name = @task, status = @status WHERE task_id = @tid";
                MySqlCommand mySqlCmd = new MySqlCommand(updateTasksQuery, mySqlConn);

                mySqlCmd.Parameters.AddWithValue("@firstname", taskToUpdate.firstName ?? " ");
                mySqlCmd.Parameters.AddWithValue("@lastname", taskToUpdate.lastName ?? " ");
                mySqlCmd.Parameters.AddWithValue("@task", taskToUpdate.task);
                mySqlCmd.Parameters.AddWithValue("@status", taskToUpdate.status);
                mySqlCmd.Parameters.AddWithValue("@tid", Int32.Parse(taskToUpdate.tid));

                Console.WriteLine("=====> " + mySqlCmd.CommandText);

                mySqlCmd.ExecuteNonQuery();

            }


        }
    }
}
