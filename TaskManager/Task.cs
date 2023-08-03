using System.Reflection;
class TaskHandler{
    public required string Name{
        get;set;
    }
    public required string Description{
        get;set;
    }
    public TaskHandlerCategory Catagory{
        get;set;
    }
    public bool IsCompleted{
        get;set;
    }

    public void PrintTaskHandler(){
        Type TaskHandlerType = typeof(TaskHandler);
        PropertyInfo[] properties = TaskHandlerType.GetProperties();

        Console.WriteLine("TaskHandler Properties:");
        foreach (PropertyInfo property in properties)
        {
            object value = property.GetValue(this)!;
            Console.WriteLine($"{property.Name}: {value}");
        }
    }   
}