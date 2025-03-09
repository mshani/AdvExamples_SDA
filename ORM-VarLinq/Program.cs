using ORM_VarLinq;

IList<Student> studentList = new List<Student>() {
new Student() { Id = 1, Name = "John", Surname = "Doe", Age = 20, DepartmentId = 1},
new Student() { Id = 2, Name = "Moin", Surname = "Smith", Age = 31, DepartmentId = 1 },
new Student() { Id = 3, Name = "Bill", Surname = "Jackson", Age = 28, DepartmentId = 2 },
new Student() { Id = 4, Name = "Ram" , Surname = "Levi" , Age = 20, DepartmentId = 1},
new Student() { Id = 5, Name = "Ron" , Surname = "Taylor" , Age = 20, DepartmentId = 3 }
};

var groupedResult1 = from s in studentList group s by s.Age;
var groupedResult2 = studentList
                    .GroupBy(s => s.Age);

foreach (var ageGroup in groupedResult1)
{
    //Each group has a key
    Console.WriteLine("Age Group: {0}", ageGroup.Key);
    //Each group has a inner collection
    foreach (Student s in ageGroup)
    {
        Console.WriteLine("Student Name: {0}", s.Name);
    }
}

IList<Department> departmentList = new List<Department>() {
 new Department(){ Id = 1, Name="Computer Science"},
 new Department(){ Id = 2, Name="Math"},
 new Department(){ Id = 3, Name="Physics"}
};

var filteredResult = from s in studentList
 where s.Age > 19 && s.Age < 29
 select s.Name;

var filteredResult2 = studentList
.Where(s => s.Age > 19 && s.Age < 29)
.Select(x => x.Name);

foreach (var item in filteredResult)
{
    Console.WriteLine($"{item}");
}

foreach (var item in filteredResult2)
{
    Console.WriteLine($"{item}");
}

var filteredResult3 = (from s in studentList
                       where s.Age > 19 && s.Age < 29 
                       select s)
                       .FirstOrDefault();

var filteredResult4 = studentList
.FirstOrDefault(s => s.Age > 19 && s.Age < 29);

var orderByResult = from s in studentList
                    orderby s.Name, s.Surname
                    select new
                    {
                        Name = s.Name,
                        Surname = s.Surname
                    };

var orderByResult2 = studentList
                    .OrderBy(s => s.Name)
                    .ThenBy(s => s.Surname)
                    .Select(s => new
                    {
                        Name = s.Name,
                        Surname = s.Surname
                    });


bool result = studentList.Select(x => x.Name).Contains("Bill");