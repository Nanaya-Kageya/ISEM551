using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using assignment.DataAccess;
using assignment.Models;

namespace assignment.Business
{
    public class TaskService
    {
        public TaskService()
        {
        }

        public static List<TaskVO> GetIndividualTasks()
        {
            //TaskVO task = new TaskVO();
            var taskList = new List<TaskVO>();

            taskList = TasksDAO.GetTasks();


            for (int i = 0; i < taskList.Count(); i++)
            {
                TaskVO task = taskList[i];
                Console.WriteLine("Printing tasks: " + task);

            }

            Console.WriteLine("Task list size: " + taskList.Count());

            return taskList;
        }

        public static List<TaskVO> GetIndividualTasks1()
        {
            //TaskVO task = new TaskVO();
            var taskList = new List<TaskVO>();
            DataSet taskResultSet = new DataSet();

            taskResultSet = TasksDAO.GetTasks1();

            if (taskResultSet.Tables.Count > 0)
            {
                taskList = taskResultSet.Tables[0].AsEnumerable().Select(m => new TaskVO
                {
                    tid = Convert.ToString(m["task_id"]),
                    firstName = Convert.ToString(m["first_name"]),
                    lastName = Convert.ToString(m["last_name"]),
                    task = Convert.ToString(m["task_name"]),
                    status = Convert.ToString(m["Status"]),
                    iteration = Convert.ToString(m["iteration"])


                }).ToList();
            }

            Console.WriteLine("Printing tasks list: " + taskList.Count());

            for (int i=0; i<taskList.Count(); i++)
            {
                TaskVO task = taskList[i];
                Console.WriteLine("Printing tasks: " + task);
            }

            return taskList;
        }

        public static List<List<TaskVO>> GetIndividualTasks2()
        {
            //TaskVO task = new TaskVO();
            var taskList = new List<List<TaskVO>>();
            var iterationList = new List<TaskVO>();
            var tempList = new List<TaskVO>();

            iterationList = TasksDAO.GetTasks();

            Console.WriteLine("Printing tasks list: " + iterationList.Count());

            for (int i = 0; i < iterationList.Count(); i++)
            {
                TaskVO task = iterationList[i];
                Console.WriteLine("Printing tasks: " + task);

                if (i % 2 == 0)
                {
                    tempList.Add(task);
                    taskList.Add(tempList);
                    tempList = new List<TaskVO>();
                }
                else
                {
                    tempList.Add(task);
                }

            }

            Console.WriteLine("Task list size: " + taskList.Count());

            return taskList;
        }
    }
}
