using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TestTaskDinamika.Wpf.Data;
using TestTaskDinamika.Wpf.Models;

namespace TestTaskDinamika.Wpf.ViewModels;
public class PersonViewModel : BaseViewModel
{
    public ICommand SaveChangesCommand { get; private set; }
    private ObservableCollection<Person> _people;
    public ObservableCollection<Person> People
    {
        get { return _people; }
        set
        {
            _people = value;
            OnPropertyChanged(nameof(People));
        }
    }
    private ObservableCollection<Company> _companies;
    public ObservableCollection<Company> Companies
    {
        get { return _companies; }
        set
        {
            _companies = value;
            OnPropertyChanged(nameof(Companies));
        }
    }
    public PersonViewModel()
    {
        using var context = new AppDbContext();
        People = new ObservableCollection<Person>(context.People.Include(p => p.Company).ToList());
        Companies = new ObservableCollection<Company>(context.Companies.Include(c => c.People).ToList());

        SaveChangesCommand = new RelayCommand(param => SaveChanges());
    }
    public void SaveChanges()
    {
        using var context = new AppDbContext();
        context.People.UpdateRange(People);
        context.SaveChanges();

        People = new ObservableCollection<Person>(context.People.Include(p => p.Company).ToList());
    }
}
