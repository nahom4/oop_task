class Driver
{
    public static async Task Main()
    {
        TaskHandlerManager TaskHandlerManagerObj = new();
        await TaskHandlerManagerObj.Read();
        TaskHandler CompleteProject =  new() {Name = "Complete Project",Description = "Complete advanced C # project in time",Catagory = TaskHandlerCategory.Work};
        TaskHandlerManagerObj.AddTaskHandler(CompleteProject);
        TaskHandlerManagerObj.DisplayTaskHandlers();
        TaskHandlerManagerObj.UpdateTaskHandler("Complete Project","Have finished working on it","Personal","true");
        TaskHandlerManagerObj.DisplayTaskHandlers();
        await TaskHandlerManagerObj.Write();
    }
}