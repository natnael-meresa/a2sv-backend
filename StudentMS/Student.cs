public class Student
{

    // I cloudn't make rollnumber read only because of serialization
    public int RollNumber {get; set; }

    public string Name { get; set; }

    public int Age {get; set;}

    public string Grade {get; set;}

    public Student(int rollNumber, string name, int age, string grade)
    {
        RollNumber = rollNumber;
        Name = name;
        Age = age;
        Grade = grade;
    }
}