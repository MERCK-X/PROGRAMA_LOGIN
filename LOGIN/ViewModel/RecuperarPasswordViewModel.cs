using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LOGIN.Models;
using LOGIN.Services;

namespace LOGIN.ViewModels;

public partial class RecuperarPasswordViewModel : ObservableObject
{
    [ObservableProperty]
    private string email;

    [ObservableProperty]
    private string nuevaPassword;

    private readonly DatabaseService _databaseService;

    public RecuperarPasswordViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    [RelayCommand]
    private async Task RecuperarPassword()
    {
        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(NuevaPassword))
        {
            await Shell.Current.DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
            return;
        }

        var usuario = await _databaseService.ObtenerUsuarioPorEmailAsync(Email);

        if (usuario == null)
        {
            await Shell.Current.DisplayAlert("Error", "El correo no está registrado", "OK");
            return;
        }

        usuario.Password = NuevaPassword;
        await _databaseService.ActualizarUsuarioAsync(usuario);

        await Shell.Current.DisplayAlert("Éxito", "Contraseña actualizada correctamente", "OK");
        await Shell.Current.GoToAsync("//Login");
    }
}