using System.Threading.Tasks;
class TaskHandlerManager
{
    readonly string FilePath = "TaskHandler.csv";
    readonly List<TaskHandler> TaskHandlerList = new();
    public void AddTaskHandler(TaskHandler TaskHandlerToBeAdded){
        var QueryString = from task in TaskHandlerList
        where task.Name == TaskHandlerToBeAdded.Name
        select task;

        if (! QueryString.Any())
        {
        TaskHandlerList.Add(TaskHandlerToBeAdded);
        }
    }

    public void UpdateTaskHandler(string Name,string Description,string Catagory,string IsCompleted)
    {
        var QueryString = 
        from task in TaskHandlerList
        where task.Name == Name
        select task;
        
        if (QueryString.Any())
        {
            TaskHandler TaskToBeUpdated = QueryString.First();
            if (Description != null)
            {
                TaskToBeUpdated.Description = Description;  
            }

            if (Enum.TryParse(Catagory, out TaskHandlerCategory category))
            {
                TaskToBeUpdated.Catagory = category;
            }

            if (bool.TryParse(IsCompleted,out bool isCompleted))
            {
                TaskToBeUpdated.IsCompleted = isCompleted;
            }
        }

        else
        {
            Console.WriteLine("Unable to Update the task");
        }
    }

    public void DisplayTaskHandlers()
    {
        foreach(TaskHandler TaskHandler in TaskHandlerList){
            TaskHandler.PrintTaskHandler();
            Console.WriteLine("--------------------------------------------");
        }
    }

    public List<TaskHandler>? FilterTaskHandlersByCatagory(TaskHandlerCategory catagory)
    {
        return TaskHandlerList.Where(t => t.Catagory.Equals(catagory)).ToList();
    }

    public async Task WriteToCsvFile()
    {
        using StreamWriter writer = new(FilePath);
        writer.Write("");
        writer.WriteLine("TaskHandlerName,Category,Description");

        foreach (TaskHandler TaskHandler in TaskHandlerList)
        {
            await writer.WriteLineAsync($"{TaskHandler.Name},{(int)TaskHandler.Catagory},{TaskHandler.Description},{TaskHandler.IsCompleted}");
        }
    }

    public async Task ReadFromCsvFile(){
        using StreamReader reader = new(FilePath);
        while (!reader.EndOfStream)
        {
            string? line = await reader.ReadLineAsync();
            string[] values = line!.Split(',');

            if (values.Length >= 4)
            {
                TaskHandler TaskHandlerObj = new()
                {
                    Name = values[0],
                    Catagory = Enum.TryParse(values[1], out TaskHandlerCategory Category) ? Category : TaskHandlerCategory.Work,
                    Description = values[2],
                    IsCompleted = !bool.TryParse(values[3], out bool isComplete) || isComplete
                };
                
                TaskHandlerList.Add(TaskHandlerObj);
            }
        }

    }

    public  async Task Read()
    {
        try
        {
            await ReadFromCsvFile();
        }
        catch(Exception e)
        {
            Console.WriteLine(e);   
        }
    }

    public async Task Write()
    {
          try
        {
            await WriteToCsvFile();
        }
        catch(Exception e)
        {
            Console.WriteLine(e);   
        }   
    }
}