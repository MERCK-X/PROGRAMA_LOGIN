using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LOGIN.Models;
using LOGIN.Services;

namespace LOGIN.ViewModels;

public partial class RegistroViewModel : ObservableObject
{
    [ObservableProperty]
    private string nombre;

    [ObservableProperty]
    private string email;

    [ObservableProperty]
    private string password;

    private readonly DatabaseService _databaseService;

    public RegistroViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    [RelayCommand]
    private async Task Registrar()
    {
        if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            await Shell.Current.DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
            return;
        }

        var usuario = new Usuario
        {
            Nombre = Nombre,
            Email = Email,
            Password = Password // Considera hashear la contraseña antes de almacenarla.
        };

        await _databaseService.GuardarUsuarioAsync(usuario);
        await Shell.Current.DisplayAlert("Éxito", "Usuario registrado correctamente", "OK");
        await Shell.Current.GoToAsync("//Login");
    }
}