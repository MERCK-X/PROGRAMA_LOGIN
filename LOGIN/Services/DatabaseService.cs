using SQLite;
using LOGIN.Models;
using System.IO;
using System.Threading.Tasks;

namespace LOGIN.Services;

public class DatabaseService
{
    private SQLiteAsyncConnection _database;

    public DatabaseService()
    {
        InitializeDatabase().Wait();
    }

    private async Task InitializeDatabase()
    {
        if (_database != null) return;

        // Ruta de la base de datos en el sistema de archivos
        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "usuarios.db3");

        // Crear la conexión a la base de datos
        _database = new SQLiteAsyncConnection(databasePath);

        // Crear la tabla de usuarios si no existe
        await _database.CreateTableAsync<Usuario>();
    }

    // Guardar un nuevo usuario
    public async Task<int> GuardarUsuarioAsync(Usuario usuario)
    {
        return await _database.InsertAsync(usuario);
    }

    // Obtener un usuario por email
    public async Task<Usuario> ObtenerUsuarioPorEmailAsync(string email)
    {
        return await _database.Table<Usuario>().FirstOrDefaultAsync(u => u.Email == email);
    }

    // Actualizar un usuario
    public async Task<int> ActualizarUsuarioAsync(Usuario usuario)
    {
        return await _database.UpdateAsync(usuario);
    }
}