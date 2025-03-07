namespace LOGIN.Views;
using LOGIN.ViewModels;
using LOGIN.Services;
public partial class PantallaRegistrarme : ContentPage
{
    public PantallaRegistrarme()
    {
        InitializeComponent();
        BindingContext = new RegistroViewModel(new DatabaseService());
    }
}