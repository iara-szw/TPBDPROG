using Microsoft.Data.SqlClient;
using Dapper;
public static class BD{

    public static string connectionString = @"Server=localhost;
    DataBase=BDintegrantes; Integrated Security=True; TrustServerCertificate=True;";
    public static void agregarIntegrante(Integrante inte){

        string query = "INSERT INTO Integrantes (inte.nombreUsuario, inte.consetrasenia, inte.DNI, inte.nombreCompleto, inte.fechaNacimiento, inte.cancionFav, inte.materiaFav) VALUES (@pnombreUsuario, @pcontrasenia, @pDNI, @pnombreCompleto, @pfechaNacimiento, @pcancionFav, @pmateriaFav)";
        using(SqlConnection connection = new SqlConnection(connectionString)){
        connection.Execute(query, new { pnombreUsuario=inte.nombreUsuario,  pcontrasenia=inte.contrasenia,pDNI=inte.DNI, pnombreCompleto=inte.nombreCompleto, pfechaNacimiento=inte.fechaNacimiento, pcancionFav=inte.cancionFav,pmateriaFav=inte.materiaFav });
        }
                
    }
     public static List<Integrante> levantarIntegrantes(){

   
        List<Integrante> integrantes= new List<Integrante>();
        using(SqlConnection connection = new SqlConnection(connectionString)){
 
        string query = "SELECT * FROM Integrantes";
        integrantes= connection.Query<Integrante>(query).ToList();
            
        }
        return integrantes;
   }

}
