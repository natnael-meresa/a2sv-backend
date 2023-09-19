public class TaskManager
{
    List<Task> tasks = new List<Task>();
    public void AddTask(Task task)
    {
        if (task == null)
        {
            throw new ArgumentNullException(nameof(task));
        }

        tasks.Add(task);
    }

    public void DisplayAllTaks()
    {
        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Name}");
            Console.WriteLine($"     Description: {task.Description}");
            Console.WriteLine($"     Completed: {(task.IsCompleted ? "Yes" : "No")}");
            Console.WriteLine($"     Categorie: {task.Category}");
        }
    }

    public void ViewTasksByCategory(TaskCategory category)
    {
        var filteredTasks = tasks.Where(task => task.Category == category);
        foreach (var task in filteredTasks)
        {
            Console.WriteLine($"{task.Name}");
            Console.WriteLine($"     Description: {task.Description}");
            Console.WriteLine($"     Category: {task.Category}");
            Console.WriteLine($"     Completed: {(task.IsCompleted ? "Yes" : "No")}");
            Console.WriteLine();
        }
    }

    public async void LoadTasksFromCsv(string filePath)
    {
        try
        {
            using (var reader = new StreamReader(filePath))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    string[] parts = line.Split(',');
                    if (Enum.TryParse(parts[2], out TaskCategory category) &&
                        bool.TryParse(parts[3], out bool isCompleted))
                    {
                        Task task = new Task
                        {
                            Name = parts[0],
                            Description = parts[1],
                            Category = category,
                            IsCompleted = isCompleted
                        };
                        tasks.Add(task);
                    }
                }
            }
        }
        catch (IOException ex)
        {
            throw ex;
        }

    }

    public async void SaveTasksAsync(string filePath)
    {

        try
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var task in tasks)
                {
                    await writer.WriteLineAsync($"{task.Name},{task.Description},{task.IsCompleted},{task.Category}");
                }
            }
        }
        catch (IOException ex)
        {
            throw ex;
        }

    }
}