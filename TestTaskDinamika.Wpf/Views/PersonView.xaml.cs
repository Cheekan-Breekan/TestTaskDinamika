using System.Windows;
using TestTaskDinamika.Wpf.ViewModels;

namespace TestTaskDinamika.Wpf.Views;
public partial class PersonView : Window
{
    public PersonView()
    {
        InitializeComponent();
        DataContext = new PersonViewModel();
    }
    public void GoToCompanyWindow_Click(object sender, RoutedEventArgs e)
    {
        var companiesWindow = new CompaniesView();
        companiesWindow.Show();
        this.Close();
    }
}
