using System.Windows;

namespace TestTaskDinamika.Wpf.Views;
public partial class CompaniesView : Window
{
    public CompaniesView()
    {
        InitializeComponent();
    }
    public void GoToCompanyWindow_Click(object sender, RoutedEventArgs e)
    {
        var personsWindow = new PersonView();
        personsWindow.Show();
        this.Close();
    }
}
