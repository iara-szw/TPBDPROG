using Microsoft.Data.SqlClient;
using Dapper;
public static class BD{

    public static string connectionString = @"Server=localhost;
    DataBase=BDintegrantes; Integrated Security=True; TrustServerCertificate=True;";
    public static void agregarIntegrante(Integrante inte){

        string query = "INSERT INTO Integrantes (nombreUsuario, password, DNI, nombreCompleto,fechaNacimiento,cancionFav,libroFav) VALUES (@pnombreUsuario, @ppassword, @pDNI, @pnombreCompleto, @pfechaNacimiento, @pcancionFav, @plibroFav)";
        using(SqlConnection connection = new SqlConnection(connectionString)){
        connection.Execute(query, new {pnombreUsuario=inte.nombreUsuario, ppassword=inte.password,pDNI=inte.DNI, pnombreCompleto=inte.nombreCompleto, pfechaNacimiento=inte.fechaNacimiento.Date, pcancionFav=inte.cancionFav, plibroFav=inte.libroFav});
        }
                
    }
     public static Integrante levantarIntegrante(string nombreUsuario, string password){
        Integrante integrante=null;
        using(SqlConnection connection = new SqlConnection(connectionString)){
 
        string query = "SELECT * FROM Integrantes WHERE nombreUsuario=@pnombreUsuario AND password=@ppassword";
        integrante= connection.QueryFirstOrDefault<Integrante>(query,new{pnombreUsuario=nombreUsuario,ppassword=password});
            
        }
        return integrante;
   }
     public static bool yaExiste(string NombreUsuario){

        Integrante integrante=null;
        using(SqlConnection connection = new SqlConnection(connectionString)){
 
        string query = "SELECT * FROM Integrantes WHERE nombreUsuario=@pnombreUsuario";
        integrante= connection.QueryFirstOrDefault<Integrante>(query,new{pnombreUsuario=NombreUsuario});
            
        }
        return integrante!=null;
   }
}
