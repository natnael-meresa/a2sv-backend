public class Program
{
    static void Main(string[] args) 
    {
        var studentList = new StudentList<Student>();

        studentList.AddStudent(new Student(1, "John Doe", 18, "A"));

        var searchedStudent = studentList.SearchByName("John Doe");
        if (searchedStudent != null) 
        {
            Console.WriteLine($"Found student: {searchedStudent.Name}");
        }
        else
        {
            Console.WriteLine("Student not found");
        }

         var searchedStudent2 = studentList.SearchByID(1);
        if (searchedStudent2 != null) 
        {
            Console.WriteLine($"Found student: {searchedStudent2.RollNumber}");
        }
        else
        {
            Console.WriteLine("Student not found");
        }

        studentList.DisplayStudents();

        studentList.SerializeToJson("student_data.json");

         // Clear the student list
        studentList.Students.Clear();

        Console.WriteLine("After Clearing");

        studentList.DeserializeFromJson("student_data.json");
        
        studentList.DisplayStudents();


    }
}