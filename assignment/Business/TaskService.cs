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

            taskList = TasksDAO.RetrieveTasks();


            for (int i = 0; i < taskList.Count(); i++)
            {
                TaskVO task = taskList[i];
                Console.WriteLine("=====> Printing tasks: " + task);

            }

            Console.WriteLine("=====> Task list size: " + taskList.Count());

            return taskList;
        }

        public static List<TaskVO> GetIndividualTasks1()
        {
            //TaskVO task = new TaskVO();
            var taskList = new List<TaskVO>();
            DataSet taskResultSet = new DataSet();

            taskResultSet = TasksDAO.RetrieveTasks1();

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

            Console.WriteLine("=====> Printing tasks list: " + taskList.Count());

            for (int i=0; i<taskList.Count(); i++)
            {
                TaskVO task = taskList[i];
                Console.WriteLine("=====> Printing tasks: " + task);
            }

            return taskList;
        }

        public static List<List<TaskVO>> GetIndividualTasks2()
        {
            //TaskVO task = new TaskVO();
            var taskList = new List<List<TaskVO>>();
            var iterationList = new List<TaskVO>();
            var tempList = new List<TaskVO>();

            iterationList = TasksDAO.RetrieveTasks();

            Console.WriteLine("=====> Printing tasks list: " + iterationList.Count());

            for (int i = 0; i < iterationList.Count(); i++)
            {
                TaskVO task = iterationList[i];
                Console.WriteLine("=====> Printing tasks: " + task);

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

            Console.WriteLine("=====> Task list size: " + taskList.Count());

            return taskList;
        }

        public static void SaveTask(List<TaskVO> tasksRequest)
        {
            if (tasksRequest == null)
            {
                throw new ArgumentNullException(nameof(tasksRequest));
            }
            var tasksToUpdate = new List<TaskVO>();

            for (int i = 1; i <= tasksRequest.Count; i++)
            {
                TaskVO task = tasksRequest[i - 1];

                if (string.IsNullOrEmpty(task.firstName) ||
                    string.IsNullOrEmpty(task.lastName) ||
                    string.IsNullOrEmpty(task.task) ||
                    string.IsNullOrEmpty(task.status))
                {
                    Console.WriteLine("TaskVO has NULL Value, error out..." + task);
                }
                else
                {
                    task.tid = i.ToString();
                    tasksToUpdate.Add(task);
                    Console.WriteLine("Added To Update List =====> " + task);
                }
            }

            Console.WriteLine("Task To Update Size : " + tasksToUpdate.Count);

            TasksDAO.UpdateTasks(tasksToUpdate);
        }

        public static void SaveTask1()
        {
            Console.WriteLine("=====> Starting Save Task1...");

            List<TaskVO> tasks = new List<TaskVO>();

            TaskVO task1 = new TaskVO();
            TaskVO task2 = new TaskVO();

            task1.firstName = "TestSave1";
            task1.lastName = "Tester101";
            task1.task = "Fun";
            task1.status = "Enjoy";
            task1.iteration = "Iteration1";
            task1.tid = "1";

            task2.firstName = "Funny";
            task2.lastName = "Stuff";
            task2.task = "LuLu";
            task2.status = "OK";
            task2.iteration = "Iteration1";
            task2.tid = "2";

            tasks.Add(task1);
            tasks.Add(task2);

            TasksDAO.UpdateTasks(tasks);
        }
    }
}
