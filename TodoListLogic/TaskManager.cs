using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListLogic
{
    public class TaskManager: ITaskManager
    {
        private List<Task> tasks;
        private int currentId;

        public TaskManager()
        {
            tasks = new List<Task>();
            currentId = 1;
        }
        // метод AddTask - для добавления задачи
        public void AddTask(string taskName, string desc)
        {
            Task newTask = new Task { Id = currentId++, Name = taskName, Description = desc };
            tasks.Add(newTask);
            Console.WriteLine($"Задача добавлена: {newTask}");
            string filePath = "todoList.txt";
            SaveTasksToFile(filePath);
        }
        // метод ShowAllTasks - для вывода всех задач
        public void ShowAllTasks()
        {
            //StreamReader streamReader = new StreamReader("todoList.txt");
            //string lines = streamReader.ReadToEnd();

            //if(streamReader.Equals(""))
            //{
            //    Console.WriteLine("Список задач пуст.");
            //}
            //else
            //{
            //    Console.WriteLine(lines);
            //}
            //streamReader.Close();

            if (tasks.Any())
            {
                Console.WriteLine("Список задач:");
                foreach (var task in tasks)
                {
                    Console.WriteLine($"{task.Id}. {task}");
                }
            }
            else
            {
                Console.WriteLine("Список задач пуст.");
            }
        }
        //  метод DeleteTask - для удаления задачи
        public void DeleteTask(int taskId)
        {
            Task taskToRemove = tasks.FirstOrDefault(task => task.Id == taskId);
            if (taskToRemove != null)
            {
                tasks.Remove(taskToRemove);
                Console.WriteLine($"Задача с ID {taskId} удалена.");
            }
            else
            {
                Console.WriteLine($"Задача с ID {taskId} не найдена.");
            }
        }
        // метод CompleteTask - для заканчивания задания
        public void CompleteTask(int taskId)
        {
            Task taskToComplete = tasks.FirstOrDefault(task => task.Id == taskId);
            if (taskToComplete != null)
            {
                taskToComplete.IsCompleted = true;
                Console.WriteLine($"Задача с ID {taskId} отмечена как выполненная.");
            }
            else
            {
                Console.WriteLine($"Задача с ID {taskId} не найдена.");
            }
        }
        // метод EditTask - для изменения задачи
        public void EditTask(int taskId, string newTaskName, string newTaskDescription)
        {
            Task taskToEdit = tasks.FirstOrDefault(task => task.Id == taskId);
            if (taskToEdit != null)
            {
                taskToEdit.Name = newTaskName;
                taskToEdit.Description = newTaskDescription;
                Console.WriteLine($"Задача с ID {taskId} изменена: {taskToEdit}");
            }
            else
            {
                Console.WriteLine($"Задача с ID {taskId} не найдена.");
            }
        }
        // метод SaveTasksToFile - для сохранения задачи в файл
        public void SaveTasksToFile(string filePath)
        {
            try
            {
                File.WriteAllLines(filePath, tasks.Select(task => $"{task.Id}|{task.Name}|{task.IsCompleted}|{task.Description}"));
                Console.WriteLine($"Задачи сохранены в файл: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении задач в файл: {ex.Message}");
            }
        }
        // метод LoadTaskFromFile - для загрузки задач с файла
        public void LoadTasksFromFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                tasks.Clear();

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3 && int.TryParse(parts[0], out int id) && bool.TryParse(parts[2], out bool isCompleted))
                    {
                        string description = parts.Length > 3 ? parts[3] : string.Empty;
                        tasks.Add(new Task { Id = id, Name = parts[1], IsCompleted = isCompleted, Description = description });
                    }
                }

                Console.WriteLine($"Задачи загружены из файла: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке задач из файла: {ex.Message}");
            }
        }
    }
}
