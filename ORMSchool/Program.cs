using ORMSchool.Services;

var service = new DepartmentService();

var department = service.GetDepartmentById(2);
if (department != null)
{
    Console.WriteLine($"{department.Id} {department.Name}");
}
else
{
    Console.WriteLine("not found");
}
