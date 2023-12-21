using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListLogic;

namespace TodoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITaskManager taskManager = new TaskManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Менеджер задач:");
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Показать все задачи");
                Console.WriteLine("3. Удалить задачу");
                Console.WriteLine("4. Завершить задачу");
                Console.WriteLine("5. Редактировать задачу");
                Console.WriteLine("6. Сохранить задачи в файл");
                Console.WriteLine("7. Загрузить задачи из файла");
                Console.WriteLine("8. Выход");

                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите название задачи: ");
                        string taskName = Console.ReadLine();
                        Console.Write("Введите описание задачи: ");
                        string desc = Console.ReadLine();
                        taskManager.AddTask(taskName, desc);
                        break;

                    case "2":
                        Console.WriteLine("Вывод всех задач");
                        taskManager.ShowAllTasks();
                        break;

                    case "3":
                        Console.Write("Введите ID задачи для удаления: ");
                        if (int.TryParse(Console.ReadLine(), out int taskIdToDelete))
                        {
                            taskManager.DeleteTask(taskIdToDelete);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод ID.");
                        }
                        break;

                    case "4":
                        Console.Write("Введите ID задачи для завершения: ");
                        if (int.TryParse(Console.ReadLine(), out int taskIdToComplete))
                        {
                            taskManager.CompleteTask(taskIdToComplete);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод ID.");
                        }
                        break;

                    case "5":
                        Console.Write("Введите ID задачи для редактирования: ");
                        if (int.TryParse(Console.ReadLine(), out int taskIdToEdit))
                        {
                            Console.Write("Введите новое название задачи: ");
                            string newTaskName = Console.ReadLine(); 
                            Console.Write("Введите новое описание задачи: ");
                            string newDescription = Console.ReadLine();
                            taskManager.EditTask(taskIdToEdit, newTaskName, newDescription);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод ID.");
                        }
                        break;

                    case "6":
                        string saveFilePath = "todoList.txt";
                        taskManager.SaveTasksToFile(saveFilePath);
                        break;

                    case "7":
                        string loadFilePath = "todoList.txt";
                        taskManager.LoadTasksFromFile(loadFilePath);
                        break;

                    case "8":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }

                Console.ReadLine();
            }
        }
    }
}
