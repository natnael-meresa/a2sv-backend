public class Program
{
    public static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();
        Task task1 = new Task("task1", "description1", false, TaskCategory.Personal);
        taskManager.AddTask(task1);
        taskManager.DisplayAllTaks();

        try{
            Console.WriteLine("read");
            taskManager.LoadTasksFromCsv("Tasks.csv");
        }
        catch(IOException ex)
        {
            Console.WriteLine($"No task found ex: {ex.Message}");
            return;
        }
        
        taskManager.DisplayAllTaks();

        try
        {
            Console.WriteLine("write");

            taskManager.SaveTasksAsync("Tasks.csv");
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        taskManager.DisplayAllTaks();

    }
}