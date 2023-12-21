using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListLogic
{
    public interface ITaskManager
    {
        void AddTask(string taskName, string desc);
        void ShowAllTasks();
        void DeleteTask(int taskId);
        void CompleteTask(int taskId);
        void EditTask(int taskId, string newTaskName, string newDescription );
        void SaveTasksToFile(string filePath);
        void LoadTasksFromFile(string filePath);
    }
}
