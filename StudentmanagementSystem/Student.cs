using System;
using System.Runtime.Serialization;

public class Student 
{
    public string Name;
    public int Age;
    public readonly int RollNumber;
    public StudentGrades Grade;

    public Student(string Name, int Age, StudentGrades Grade)
    {
        this.Name = Name;
        this.Age = Age;
        this.Grade = Grade;
        RollNumber = StudentList<Student>.Container.Count + 1; 
    }

    // public Student(SerializationInfo info, StreamingContext context)
    // {
    //     Name = info.GetString("Name");
    //     Age = info.GetInt32("Age");
    //     RollNumber = info.GetInt32("RollNumber");
    //     Grade = (StudentGrades)info.GetValue("Grade", typeof(StudentGrades));
    // }

    // public void GetObjectData(SerializationInfo info, StreamingContext context)
    // {
    //     info.AddValue("Name", Name);
    //     info.AddValue("Age", Age);
    //     info.AddValue("RollNumber", RollNumber);
    //     info.AddValue("Grade", Grade);
    // }
}

