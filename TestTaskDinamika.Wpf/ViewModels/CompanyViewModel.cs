using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TestTaskDinamika.Wpf.Data;
using TestTaskDinamika.Wpf.Models;

namespace TestTaskDinamika.Wpf.ViewModels;
public class CompanyViewModel : BaseViewModel
{
    public ICommand SaveChangesCommand { get; private set; }

    private ObservableCollection<Company> _companies;
    public ObservableCollection<Company> Companies
    {
        get => _companies;
        set
        {
            _companies = value;
            OnPropertyChanged();
        }
    }

    public CompanyViewModel()
    {
        using var context = new AppDbContext();
        Companies = new ObservableCollection<Company>(context.Companies.Include(c => c.People).ToList());

        SaveChangesCommand = new RelayCommand(param => SaveChanges());
    }

    public void SaveChanges()
    {
        using var context = new AppDbContext();
        context.Companies.UpdateRange(Companies);
        context.SaveChanges();
    }
}
