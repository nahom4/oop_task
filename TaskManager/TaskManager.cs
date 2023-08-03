using System.Threading.Tasks;
class TaskHandlerManager
{
    string FilePath = "C:/Users/A/Desktop/TaskManager/TaskHandler.csv";
    List<TaskHandler> TaskHandlerList = new List<TaskHandler>();
    public void AddTaskHandler(TaskHandler TaskHandlerToBeAdded){
        TaskHandlerList.Add(TaskHandlerToBeAdded);
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
         using (StreamWriter writer = new StreamWriter(FilePath))
        {   writer.Write("");
            writer.WriteLine("TaskHandlerName,Category,Description");

            foreach (TaskHandler TaskHandler in TaskHandlerList){
                await writer.WriteLineAsync($"{TaskHandler.Name},{(int) TaskHandler.Catagory},{TaskHandler.Description},{TaskHandler.IsCompleted}");
        }
        
    }
    }

    public async Task ReadFromCsvFile(){
        using (StreamReader reader = new StreamReader(FilePath)){
            while (!reader.EndOfStream)
            {
                string? line = await reader.ReadLineAsync();
                string[] values = line!.Split(',');
                
                if (values.Length >= 4)
                {   Enum.TryParse<TaskHandlerCategory>(values[1],out TaskHandlerCategory category);
                    bool.TryParse(values[3],out bool isComplete);
                    TaskHandler TaskHandler = new TaskHandler
                    {
                        Name = values[0],
                        Catagory = category,
                        Description = values[2],
                        IsCompleted = isComplete
                    };
                    TaskHandlerList.Add(TaskHandler);
                }    
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