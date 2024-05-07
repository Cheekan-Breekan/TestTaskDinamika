namespace TestTaskDinamika.Wpf.Models;
public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Person> People { get; set; } = [];
}
