// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, This Grade Calulator System!");
Console.Write("Please Enter Your Name: ");

string? name;
name  = Console.ReadLine();

if (name == null || name == "") {
    throw new ArgumentNullException("name should not be empty");
}

Console.Write("Please Enter Your Number of Subject: ");
Int32 subject_num;

subject_num = Convert.ToInt32(Console.ReadLine());

if (subject_num == 0) {
    throw new ArgumentNullException("subject number should not be empty");
}

if (subject_num < 0 || subject_num > 100) {
    throw new ArgumentOutOfRangeException("subject should be in the range of 0 to 100");
}

Dictionary<string, decimal> gradedict = new Dictionary<string, decimal>();

for (int i = 0; i < subject_num; i++) {
    string? subject_name;
    Console.Write("Please Enter Subject Name: ");
    subject_name = Console.ReadLine();

    decimal subject_grade;
    Console.Write("Please Enter Subject Grade: ");
    subject_grade = Convert.ToDecimal(Console.ReadLine());

    if (subject_name != null && !gradedict.ContainsKey(subject_name)) {
        gradedict.Add(subject_name, subject_grade);
    }

}

Console.WriteLine("Calculating Grade >>>");

Avarage avarage = new Avarage();
decimal avarageGrade = avarage.CalulateAvarage(gradedict, subject_num);

Console.WriteLine($"Student Name: {name}, Avarage Grade: {avarageGrade}");