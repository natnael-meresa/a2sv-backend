using System.Text.Json;

public class StudentList<T> where T : Student
{
    public List<T> Students {get; set;}

    public StudentList()
    {
        Students = new List<T>();
    }

    public void AddStudent(T student)
    {
        Students.Add(student);
    }

   public void SerializeToJson(string fileName)
    {
        string json = JsonSerializer.Serialize(Students);
        File.WriteAllText(fileName, json);
    }

    public void DeserializeFromJson(string fileName)
    {
        string json = File.ReadAllText(fileName);
        if (json is not null) {
            Students = JsonSerializer.Deserialize<List<T>>(json);
        }
    }

    public T SearchByName(string name)
    {
        var query =
            from student in Students
            where student.Name == name
            select student;
            
        var searchedStudent =  query.FirstOrDefault();
        if (searchedStudent != null) {
            return searchedStudent;
        }

        return Students[1];
    }

     public T SearchByID(int rollNumber)
    {
        var query =
            from student in Students
            where student.RollNumber == rollNumber
            select student;

        var searchedStudent =  query.FirstOrDefault();
        if (searchedStudent != null) {
            return searchedStudent;
        }

        return Students[1];
    }

     public void DisplayStudents()
    {
        foreach (var student in Students)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Roll Number: {student.RollNumber}, Grade: {student.Grade}");
        }
    }
}