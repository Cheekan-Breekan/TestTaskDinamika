using System.Collections.ObjectModel;
using System.Windows.Input;
using TestTaskDinamika.Wpf.Data;
using TestTaskDinamika.Wpf.Logger;
using TestTaskDinamika.Wpf.Models;

namespace TestTaskDinamika.Wpf.ViewModels;
public class AddEditPersonViewModel : BaseViewModel
{
    private Person _person;
    public Person Person
    {
        get { return _person; }
        set
        {
            _person = value;
            OnPropertyChanged();
        }
    }

    private ObservableCollection<Company> _companies;
    public ObservableCollection<Company> Companies
    {
        get { return _companies; }
        set
        {
            _companies = value;
            OnPropertyChanged();
        }
    }
    public ICommand SaveChangesCommand { get; private set; }

    public AddEditPersonViewModel()
    {
        using var context = new AppDbContext();
        Companies = new ObservableCollection<Company>(context.Companies.ToList());
        SaveChangesCommand = new RelayCommand(SaveChanges);
    }
    private void SaveChanges(object param)
    {
        try
        {
            using var context = new AppDbContext();
            context.People.Update(Person);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex.ToString());
        }
        
    }
}
