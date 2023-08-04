class UserInterface
{
    public List<Student> DisplayGroupOfStudents = new List<Student>();
    public void WelcomePage()
    {
        while(true)
        {
             Console.WriteLine("Welcome to the Student Management Application");
        Console.WriteLine("Insert What you want to perform. You can Add,Search and View All Students. Enter xit to exit");
        string option = Console.ReadLine().Trim().ToLower();

        switch(option)
        {
            case "add":
            AddStudent();
            break;

            case "search":
            SearchStudent();
            break;

            case "view":
            ViewStudents();
            break;

            case "exit":
            return;
        }
        }
       
    }

    public void AddStudent()
    {
        string Name;
        int Age;
        StudentGrades Grade;

        Console.WriteLine("Name : ");
        Name = Console.ReadLine();

        Console.WriteLine("Age : ");
        Age = int.Parse(Console.ReadLine());
        Console.WriteLine("Grade : ");
        Enum.TryParse(Console.ReadLine(), out StudentGrades grade);
        Grade = grade; 

        StudentList<Student>.AddStudent(new Student(Name,Age,Grade));
    }

    public void SearchStudent()
    {
        Console.WriteLine("You can search either by Id or Name");
        string SearchOption = Console.ReadLine().Trim().ToLower();

        if(SearchOption == "id")
        {   
            Console.WriteLine("ID : ");
            int Id = int.Parse(Console.ReadLine()); 
            DisplayGroupOfStudents = StudentList<Student>.SelectStudentsById(Id);
            StudentList<Student>.DisplayGroupOfStudents(DisplayGroupOfStudents);

        }

        if(SearchOption == "name")
        {
            Console.WriteLine("Name : ");
            string Name = Console.ReadLine();
            DisplayGroupOfStudents= StudentList<Student>.SelectStudentsByName(Name);
            Console.WriteLine(DisplayGroupOfStudents[0]);
            StudentList<Student>.DisplayGroupOfStudents(DisplayGroupOfStudents);
        }
    }

    public void ViewStudents()
    {
        StudentList<Student>.DisplayAllStudents();
    }
}