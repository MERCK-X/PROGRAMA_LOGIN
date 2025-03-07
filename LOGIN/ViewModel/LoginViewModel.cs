using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LOGIN.Models;
using LOGIN.Services;

namespace LOGIN.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private string email;

    [ObservableProperty]
    private string password;

    private readonly DatabaseService _databaseService;

    public LoginViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    [RelayCommand]
    private async Task IniciarSesion()
    {
        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            await Shell.Current.DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
            return;
        }

        var usuario = await _databaseService.ObtenerUsuarioPorEmailAsync(Email);

        if (usuario == null || usuario.Password != Password)
        {
            await Shell.Current.DisplayAlert("Error", "Correo o contraseña incorrectos", "OK");
            return;
        }

        await Shell.Current.DisplayAlert("Éxito", "Inicio de sesión exitoso", "OK");
        await Shell.Current.GoToAsync("//MainPage");
    }
}