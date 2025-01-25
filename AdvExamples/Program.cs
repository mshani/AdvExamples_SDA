//{7,8,10,5,6} => 7.2
//{7,4,10,5,6} => 7
//{4,4,4,4,4} => null
//{} => null
//{7,11,10,5,6} => 7


using AdvExamples;
try
{
    Student student = new Student()
    {
        Name = "Andi",
        Surname = "Bega"
    };
    var subject = new StudentSubject()
    {
        Name = "Introduction",
        Credits = 7,
        Grade = 9
    };
    student.AddGrade(subject);
    var subject2 = new StudentSubject()
    {
        Name = "Algebra",
        Credits = 4,
        Grade = 7
    };
    student.AddGrade(subject2);

    var subject3 = new StudentSubject()
    {
        Name = "Introduction",
        Credits = 3,
        Grade = 9
    };
    student.AddGrade(subject3);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
