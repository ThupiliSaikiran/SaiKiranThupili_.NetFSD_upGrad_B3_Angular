namespace ConsoleApp8
{
    class ToDo
    {
        List<string> tasks = new List<string>();

        public void AddTask(string task)
        {

            if (task == "")
            {
                Console.WriteLine("Enter the Task Correctly");
            }
            else
            {
                tasks.Add(task.Trim());
                Console.WriteLine("Task Added!");

            }
            Console.WriteLine();

        }

        public void ViewTask()
        {
            Console.WriteLine();
            Console.WriteLine("------ Tasks ------");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
            Console.WriteLine();
        }

        public void RemoveTask(int taskNumber)
        {

            if (taskNumber > tasks.Count || taskNumber <= 0)
            {
                Console.WriteLine("Invalid Task Number");
            }
            else
            {
                string removeTask = tasks[taskNumber - 1];
                tasks.RemoveAt(taskNumber - 1);
                Console.WriteLine($"Removed: {removeTask}");
            }
            Console.WriteLine();
        }

    }

    class Program
    {
        
        static void Main()
        {
            ToDo obj = new ToDo();

            while (true)
            {
                Console.WriteLine("To-Do List Manager");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine();
                        Console.Write("Enter Task: ");
                        string task = Console.ReadLine();
                        obj.AddTask(task);
                        break;
                    case 2:
                        obj.ViewTask();
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.Write("Enter Task Number: ");
                        int taskNumber=int.Parse(Console.ReadLine());
                        obj.RemoveTask(taskNumber);
                        break;
                    case 4:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Seclect Correct option!!");
                        break;
                }

                Console.WriteLine();
            }

           
        }
    }

}
