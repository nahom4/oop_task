class Driver
{
    public static void Main()
    {
    StudentList<Student>.DeserializeFromJsonFile();
     Student Abebe = new Student("Abebe",21,StudentGrades.A);  
     StudentList<Student>.AddStudent(Abebe);
     UserInterface ui = new UserInterface();
     ui.WelcomePage();
     StudentList<Student>.SerializeToJsonFile();







    }
}