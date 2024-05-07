using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TestTaskDinamika.Wpf.Data;
using TestTaskDinamika.Wpf.Models;
using TestTaskDinamika.Wpf.Views;

namespace TestTaskDinamika.Wpf.ViewModels;
public class PersonViewModel : BaseViewModel
{
    public ICommand EditPersonCommand { get; private set; }
    public ICommand AddPersonCommand { get; private set; }
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
    public PersonViewModel()
    {
        using var context = new AppDbContext();
        People = new ObservableCollection<Person>(context.People.Include(p => p.Company).ToList());

        EditPersonCommand = new RelayCommand(EditPerson);
        AddPersonCommand = new RelayCommand(AddPerson);
    }
    public void EditPerson(object param)
    {
        if (param is Person person)
        {
            var editPersonWindow = new AddEditPersonView();
            var editPersonViewModel = new AddEditPersonViewModel();
            editPersonViewModel.Person = person;
            editPersonWindow.DataContext = editPersonViewModel;
            editPersonWindow.ShowDialog();
        }
    }
    public void AddPerson(object param)
    {
        var editPersonWindow = new AddEditPersonView();
        var editPersonViewModel = new AddEditPersonViewModel();
        editPersonViewModel.Person = new Person();
        editPersonWindow.DataContext = editPersonViewModel;
        editPersonWindow.ShowDialog();
    }
}
