public class Task
{
    public string Name { get; set; }
    public String Description { get; set; }
    public Boolean IsCompleted { get; set;}

    public TaskCategory Category {set; get;}

    public Task()
    {
        this.Name = "";
        this.Description = "";
        this.IsCompleted = false;
        this.Category = TaskCategory.None;
    
    }
    
    public Task(string name, string description, Boolean isCompleted, TaskCategory category)
    {
        this.Name = name;
        this.Description = description;
        this.IsCompleted = isCompleted;
        this.Category = category;
    }

}