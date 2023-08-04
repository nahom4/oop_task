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
}

