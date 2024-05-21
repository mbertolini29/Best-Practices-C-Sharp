using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowMenuTaskList();
                }
                else{
                    Console.WriteLine("Opcion incorrecta.");
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");
            Console.WriteLine("----------------------------------------");

            // Read line
            try
            {
                string selectedMenu = Console.ReadLine();
                return Convert.ToInt32(selectedMenu);
            }
            catch(Exception)
            {
                Console.WriteLine("Opción incorrecta. Seleccione una opción del menú.");
                return -1;
            }                    
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                
                ShowCurrentTasks();
                //ShowMenuTaskList();

                string taskNumberToDelete = Console.ReadLine();
                
                // Remove one position
                int indexToRemove = Convert.ToInt32(taskNumberToDelete) - 1;
                
                if(indexToRemove > (TaskList.Count - 1) || indexToRemove < 0) 
                    Console.WriteLine("El numero de tarea seleccionado no es valido");
                else
                {
                    if (indexToRemove > -1 && TaskList.Count > 0)
                    {
                        string taskRemove = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine($"Tarea {taskRemove} eliminada");
                    }
                }
            }
            catch (Exception) //--> si presiona el numero incorrecto..
            {
                Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string addTask = Console.ReadLine();

                if(!string.IsNullOrEmpty(addTask))
                {
                    TaskList.Add(addTask);
                    Console.WriteLine("Tarea registrada.");
                }
                else{                    
                    Console.WriteLine("el ingreso no es valido.");
                    Console.WriteLine("Se requiere el nombre de la tarea.");                
                }
            }
            catch (Exception)
            {
                //el error seria que no ingrese nada..
                Console.WriteLine("Ha ocurrido un error al ingresar la tarea.");
            }
        }

        public static void ShowMenuTaskList()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                ShowCurrentTasks();
            }
        }

        public static void ShowCurrentTasks()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Tareas pendientes:");

            var indexTask = 1;
            TaskList.ForEach(task => Console.WriteLine($"{indexTask++} . {task}"));
            
            // for (int i = 0; i < TaskList.Count; i++)
            // {
            //     Console.WriteLine((i + 1) + ". " + TaskList[i]);
            // }

            Console.WriteLine("----------------------------------------");
        }

    }

    public enum Menu{
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4
    }
}
