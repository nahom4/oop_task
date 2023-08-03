class Driver{
    public static async Task Main(){

        TaskHandlerManager TaskHandlerManagerObj = new TaskHandlerManager();
        await TaskHandlerManagerObj.Read();
        TaskHandler CompleteProject = new TaskHandler{Name = "Complete Project",Description = "Complete advanced C # project in time",Catagory = TaskHandlerCategory.Work};
        TaskHandlerManagerObj.AddTaskHandler(CompleteProject);
        TaskHandlerManagerObj.DisplayTaskHandlers();
        await TaskHandlerManagerObj.Write();
    }
}