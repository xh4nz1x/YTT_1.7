using System.Globalization;
using Newtonsoft.Json;

namespace Diary
{
    class Diary
    {
        public static string path = "diary.json";
        
        static void Main(string[] args)
        {
            if (File.Exists(path) == false)
            {
                var file = File.Create(path);
                file.Close();
            }
            
            Console.WriteLine("\nПрограмма для просмотра/редактирования задач");
            string textMenu = "\n-----> Меню <-----\nВыберите: \n 1 - Просмотреть задачи \n 2 - Добавить новую задачу \n 3 - Удалить задачу \n 4 - Отредактировать задачу \n 5 - Завершить работу программы\n";
            string textView= "\n-----> Просмотр задач <-----\nВыберите: \n 1 - Просмотреть актуальные задачи \n 2 - Вывести список всех задач, которые уже прошли \n 3 - Вывести все задачи \n 4 - Вернуться обратно \n";
            string textViewPresent = "\n-----> Просмотр актуальных задач <-----\nВыберите: \n 1 - Вывести все задачи \n 2 - Вывести задачи на сегодня \n 3 - Вывести задачи на завтра \n 4 - Вывести задачи на неделю \n 5 - Вернуться обратно\n";
            string textEdit = "\n-----> Редактирование задачи <-----\nВыберите: \n 1 - Изменить название задачи \n 2 - Изменить описание задачи \n 3 - Изменить дату и время \n 4 - Вернуться обратно\n";

            bool programWork = true;
            while (programWork == true)
            {
                Console.WriteLine(textMenu);

                string selectCommandStrMenu = Console.ReadLine();
                int selectCommandMenu = StringToInt(selectCommandStrMenu);

                if (selectCommandMenu == 1)
                {
                    List<Tasks> allTasks = ReadALLJsonFile();
                    
                    if (allTasks.Count == 0)
                    {
                        Console.WriteLine("\n-----Задачи отсутствуют!-----");
                    }
                    else
                    {
                        bool view = true;
                        while (view == true)
                        {
                            Console.WriteLine(textView);

                            string selectCommandStrView = Console.ReadLine();
                            int selectCommandView = StringToInt(selectCommandStrView);

                            if (selectCommandView == 1)
                            {
                                bool viewPresent = true;
                                while (viewPresent == true)
                                { 
                                    List<Tasks> allTasksPresent = ReadALLPresentJsonFile();
                    
                                    if (allTasks.Count == 0)
                                    {
                                        Console.WriteLine("\n-----Задачи отсутствуют!-----");
                                    }

                                    else
                                    {
                                        Console.WriteLine(textViewPresent);

                                        string selectCommandStrViewPresent = Console.ReadLine();
                                        int selectCommandViewPresent = StringToInt(selectCommandStrViewPresent);

                                        if (selectCommandViewPresent == 1)
                                        {
                                            Console.Write("----------------------------------------"); 
                                            
                                            foreach (var task in allTasksPresent) 
                                            { 
                                                Console.WriteLine(task); 
                                            } 
                                            
                                            Console.WriteLine("----------------------------------------"); 
                                        }
                                        
                                        else if (selectCommandViewPresent == 2) 
                                        { 
                                            List<Tasks> allTodayTasks = ReadAllTodayJsonFile();
                                            
                                            if (allTodayTasks.Count == 0) 
                                            { 
                                                Console.WriteLine("\n-----Задачи на сегодня - отсутствуют!-----"); 
                                            }
                                            
                                            else 
                                            { 
                                                Console.Write("----------------------------------------");
                                                
                                                foreach (var task in allTodayTasks) 
                                                { 
                                                    Console.WriteLine(task); 
                                                }
                                                
                                                Console.WriteLine("----------------------------------------"); 
                                            } 
                                        }
                                        
                                        else if (selectCommandViewPresent == 3) 
                                        { 
                                            List<Tasks> allTomorrowTasks = ReadAllTomorrowJsonFile();
                                            
                                            if (allTomorrowTasks.Count == 0) 
                                            { 
                                                Console.WriteLine("\n-----Задачи на завтра - отсутствуют!-----"); 
                                            }
                                            
                                            else 
                                            { 
                                                Console.Write("----------------------------------------");
                                                
                                                foreach (var task in allTomorrowTasks) 
                                                { 
                                                    Console.WriteLine(task); 
                                                }
                                                
                                                Console.WriteLine("----------------------------------------"); 
                                            } 
                                        }
                                        
                                        else if (selectCommandViewPresent == 4) 
                                        { 
                                            List<Tasks> allWeekTasks = ReadAllWeekJsonFile();
                                            
                                            if (allWeekTasks.Count == 0) 
                                            { 
                                                Console.WriteLine("\n-----Задачи на неделю - отсутствуют!-----"); 
                                            }
                                            
                                            else 
                                            { 
                                                Console.Write("----------------------------------------");
                                                
                                                foreach (var task in allWeekTasks) 
                                                { 
                                                    Console.WriteLine(task); 
                                                }
                                                
                                                Console.WriteLine("----------------------------------------"); 
                                            } 
                                        }
                                        
                                        else if (selectCommandViewPresent == 5) 
                                        { 
                                            viewPresent = false; 
                                        }
                                        
                                        else 
                                        { 
                                            Console.WriteLine("\n-----Данная команда - отсутствует!-----"); 
                                        } 
                                    }
                                }
                            }
                            
                            else if (selectCommandView == 2)
                            {
                                List<Tasks> allPastTasks = ReadAllPastJsonFile();
                                        
                                if (allPastTasks.Count == 0) 
                                { 
                                    Console.WriteLine("\n-----Задачи на неделю - отсутствуют!-----"); 
                                }
                                else 
                                { 
                                    Console.Write("----------------------------------------"); 
                                            
                                    foreach (var task in allPastTasks) 
                                    { 
                                        Console.WriteLine(task); 
                                    } 
                                            
                                    Console.WriteLine("----------------------------------------"); 
                                }
                            }
                            
                            else if (selectCommandView == 3)
                            {
                                Console.Write("----------------------------------------"); 
                                            
                                foreach (var task in allTasks) 
                                { 
                                    Console.WriteLine(task); 
                                } 
                                            
                                Console.WriteLine("----------------------------------------"); 
                            }
                            
                            else if (selectCommandView == 4)
                            {
                                view = false;
                            }

                            else
                            {
                                Console.WriteLine("\n-----Данная команда - отсутствует!-----"); 
                            }
                        }
                    }
                }

                else if (selectCommandMenu == 2)
                {
                    Console.Write("-----> Введите название задачи: ");
                    string title = Console.ReadLine();
                    Console.Write("-----> Введите описание задачи: ");
                    string description = Console.ReadLine();
                    DateTime DateTime;
                    while (true)
                    {
                        Console.Write("-----> Введите дату и время (в формате ДД.ММ.ГГГГ ЧЧ:ММ): ");
                        string dateTimeStr = Console.ReadLine();

                        if (DateTime.TryParseExact(dateTimeStr, "dd.MM.yyyy HH:mm", null, DateTimeStyles.None, out DateTime))
                        {
                            if (DateTime < DateTime.Now)
                            {
                                Console.WriteLine("\n-----Введите актуальные дату и время!-----");
                            }
                            
                            else
                            {
                                break;
                            }
                        }
                        
                        else
                        {
                            Console.WriteLine("\n-----Введите дату и время в правильном формате!-----");
                        }
                    }

                    Tasks newTask = new Tasks(0, title, description, DateTime);
                    SaveToJsonFile(newTask);

                    Console.WriteLine("\n-----Задача успешно добавлена!-----");
                }
                else if (selectCommandMenu == 3)
                {
                    Console.Write("-----> Введите номер задачи: ");
                    string idStr = Console.ReadLine();
                    int id = StringToInt(idStr);

                    if (id == 0)
                    {
                        Console.WriteLine("\n-----Данной задачи - нет!-----");
                    }
                    
                    else
                    {
                        bool result = DeleteFromJsonFile(id);

                        if (result == true)
                        {
                            Console.WriteLine("\n-----Задача успешно удалена!-----");
                        }
                        
                        else
                        {
                            Console.WriteLine("\n-----Данной задачи - нет!-----");
                        }
                    }
                }
                else if (selectCommandMenu == 4)
                {
                    Console.Write("-----> Введите номер задачи: ");
                    string idStr = Console.ReadLine();
                    int id = StringToInt(idStr);

                    if (id == 0)
                    {
                        Console.WriteLine("\n-----Данной задачи - нет!-----");
                    }

                    List<Tasks> allTasks = ReadALLJsonFile();
                    if (allTasks.Count == 0)
                    {
                        Console.WriteLine("\n-----В данный момент - задачи отсутствуют!-----");
                    }
                    
                    else
                    {
                        List<Tasks> requiredTask = ReadRequiredTaskFromJsonFile(id);
                        if (requiredTask != null)
                        {
                            bool edit = true; 
                            while (edit == true) 
                            {
                                Console.WriteLine(textEdit);
                                
                                string selectCommandStr3 = Console.ReadLine(); 
                                int selectCommand3 = StringToInt(selectCommandStr3);
                                
                                if (selectCommand3 == 1) 
                                {
                                    requiredTask = ReadRequiredTaskFromJsonFile(id);
                                    
                                    Console.Write("-----> Введите название задачи: "); 
                                    string title = Console.ReadLine();
                                    
                                    foreach (var task in requiredTask)
                                    {
                                        string taskDescription = task.Description;
                                        DateTime taskDateTime = task.DateTime;
                                        Tasks editTask = new Tasks(id, title, taskDescription, taskDateTime);
                                        EditTaskFromJsonFile(editTask, id);
                                    }
                                    Console.WriteLine("\n-----Название задачи было успешно изменено!-----");
                                    
                                }
                                
                                else if (selectCommand3 == 2) 
                                {
                                    requiredTask = ReadRequiredTaskFromJsonFile(id);
                                    
                                    Console.Write("-----> Введите описание задачи: "); 
                                    string description = Console.ReadLine();
                                    
                                    foreach (var task in requiredTask)
                                    {
                                        string taskTitle = task.Title;
                                        DateTime taskDateTime = task.DateTime;
                                        Tasks editTask = new Tasks(id, taskTitle, description, taskDateTime);
                                        EditTaskFromJsonFile(editTask, id);
                                    }
                                    
                                    Console.WriteLine("\n-----Описание задачи, было успешно изменено!-----");
                                }
                                
                                else if (selectCommand3 == 3) 
                                { 
                                    requiredTask = ReadRequiredTaskFromJsonFile(id);
                                    DateTime DateTime; 
                                    while (true) 
                                    {
                                        Console.Write("-----> Введите дату и время (в формате ДД.ММ.ГГГГ ЧЧ:ММ): "); 
                                        string dateTimeStr = Console.ReadLine();
                                        
                                        if (DateTime.TryParseExact(dateTimeStr, "dd.MM.yyyy HH:mm", null, DateTimeStyles.None, out DateTime)) 
                                        {
                                            if (DateTime < DateTime.Now) 
                                            {
                                                Console.WriteLine("\n-----Введите актуальные дату и время!-----"); 
                                            }
                                            
                                            else 
                                            {
                                                break; 
                                            }
                                        }
                                        
                                        else 
                                        { 
                                            Console.WriteLine("\n-----Введите дату и время в правильном формате!-----"); 
                                        } 
                                    }

                                    foreach (var task in requiredTask)
                                    {
                                        string taskTitle = task.Title;
                                        string taskDescription = task.Description;
                                        Tasks editTask = new Tasks(id, taskTitle, taskDescription, DateTime);
                                        EditTaskFromJsonFile(editTask, id);
                                    }
                                    
                                    Console.WriteLine("\n-----Дата и время задачи, были успешно изменены!-----");
                                }
                                else if (selectCommand3 == 4) 
                                {
                                    edit = false; 
                                }
                                
                                else 
                                {
                                    Console.WriteLine("\n-----Данная команда - отсутствует!-----"); 
                                }
                            }
                        }
                        
                        else
                        {
                            Console.WriteLine("\n-----Данной задачи - нет!-----"); 
                        }
                    }
                }

                else if (selectCommandMenu == 5)
                {
                    Console.WriteLine("\n-----Завершение работы программы!-----");
                    programWork = false;
                    break;
                }
                
                else
                {
                    Console.WriteLine("\n-----Данная команда - отсутствует!-----");
                }
            }
        }
        static int StringToInt(string inputStr)
        {
            int input = 0;
            try
            {
                input = Convert.ToInt32(inputStr);
            }
            
            catch (FormatException)
            {
                Console.WriteLine("\n-----Ошибка ввода!-----");
            }

            return input;
        }
        
        static List<Tasks> ReadALLJsonFile()
        {
            string file = File.ReadAllText(path);
            List<Tasks> tasks = JsonConvert.DeserializeObject<List<Tasks>>(file);
            
            if (tasks == null)
            {
                tasks = new List<Tasks>();
            }
            
            return tasks;
        }
        
        static List<Tasks> ReadALLPresentJsonFile()
        {
            string file = File.ReadAllText(path);
            List<Tasks> tasks = JsonConvert.DeserializeObject<List<Tasks>>(file);
            
            if (tasks == null)
            {
                tasks = new List<Tasks>();
            }
            
            List<Tasks> tasksPresent = tasks.FindAll(Tasks => DateTime.Now.Date <= Tasks.DateTime.Date && Tasks.DateTime.TimeOfDay > DateTime.Now.TimeOfDay);
            
            return tasksPresent;
        }
        
        static List<Tasks> ReadRequiredTaskFromJsonFile(int id)
        {
            string file = File.ReadAllText(path);
            List<Tasks> tasks = JsonConvert.DeserializeObject<List<Tasks>>(file);

            List<Tasks> requiredTask = tasks.FindAll(Tasks => Tasks.Id == id);

            return requiredTask;
        }
        
        static List<Tasks> ReadAllTodayJsonFile()
        {
            string file = File.ReadAllText(path);
            List<Tasks> tasks = JsonConvert.DeserializeObject<List<Tasks>>(file);

            List<Tasks> tasksToday = tasks.FindAll(Tasks => Tasks.DateTime.Date == DateTime.Today && Tasks.DateTime.TimeOfDay > DateTime.Now.TimeOfDay);

            return tasksToday;
        }
        
        static List<Tasks> ReadAllTomorrowJsonFile()
        {
            string file = File.ReadAllText(path);
            List<Tasks> tasks = JsonConvert.DeserializeObject<List<Tasks>>(file);

            List<Tasks> tasksTomorrow = tasks.FindAll(Tasks => Tasks.DateTime.Date == DateTime.Today.AddDays(1));
            
            return tasksTomorrow;
        }
        
        static List<Tasks> ReadAllWeekJsonFile()
        {
            string file = File.ReadAllText(path);
            List<Tasks> tasks = JsonConvert.DeserializeObject<List<Tasks>>(file);
            
            List<Tasks> tasksWeek = tasks.FindAll(Tasks => DateTime.Now.Date <= Tasks.DateTime.Date && Tasks.DateTime.Date <= DateTime.Today.AddDays(7) && Tasks.DateTime.TimeOfDay > DateTime.Now.TimeOfDay);
            
            return tasksWeek;
        }
        
        static List<Tasks> ReadAllPastJsonFile()
        {
            string file = File.ReadAllText(path);
            List<Tasks> tasks = JsonConvert.DeserializeObject<List<Tasks>>(file);

            List<Tasks> tasksPast = tasks.FindAll(Tasks => Tasks.DateTime.Date >= DateTime.Today && Tasks.DateTime.TimeOfDay < DateTime.Now.TimeOfDay);

            return tasksPast;
        }
        
        static void EditTaskFromJsonFile(Tasks editTask, int id)
        {
            
            List<Tasks> allTasks = ReadALLJsonFile();
            int index = allTasks.FindIndex(Tasks => Tasks.Id == id);
            if (index != -1)
            {
                allTasks[index] = editTask;
            }

            string serializedTasks = JsonConvert.SerializeObject(allTasks);
            
            File.WriteAllText(path, serializedTasks);
        }
        
        static void SaveToJsonFile(Tasks task)
        {
            List<Tasks> allTasks = ReadALLJsonFile();
            int lastId;
            if (allTasks.Count == 0)
            {
                lastId = 0;
            }
            
            else
            {
                lastId = allTasks.Last().Id;
            }
            
            task.SetNewId(lastId + 1);
            
            allTasks.Add(task);

            string serializedTasks = JsonConvert.SerializeObject(allTasks);
            
            File.WriteAllText(path, serializedTasks);
        }
        
        static void SaveToJsonFile(List<Tasks> tasks)
        {
            string serializedTasks = JsonConvert.SerializeObject(tasks);
            
            File.WriteAllText(path, serializedTasks);
        }
        static bool DeleteFromJsonFile(int id)
        {
            List<Tasks> allTasks = ReadALLJsonFile();
            
            bool result = false;

            Tasks delTask = allTasks.FirstOrDefault(Tasks => Tasks.Id == id);
            
            if (delTask != null)
            {
                allTasks.Remove(delTask);
                SaveToJsonFile(allTasks);
                result = true;
            }

            return result;
        }
    }
}