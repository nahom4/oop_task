class Driver
{
    public static async Task Main()
    {
    await StudentList<Student>.DeserializeFromJsonFile();
     UserInterface ui = new UserInterface();
     ui.WelcomePage();
     StudentList<Student>.SerializeToJsonFile();
    }
}