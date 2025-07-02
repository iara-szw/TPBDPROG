using Microsoft.Data.SqlClient;
using Dapper;
class BD{


    public void agregarIntegrante(Integrante inte){

        string query = "INSERT INTO Integrantes (inte.nombreUsuario, inte.consetrasenia, inte.DNI, inte.nombreCompleto, inte.fechaNacimiento, inte.cancionFav, inte.materiaFav) VALUES (@pnombreUsuario, @pcontrasenia, @pDNI, @pnombreCompleto, @pfechaNacimiento, @pcancionFav, @pmateriaFav)";
        using(SqlConnection connection = new SqlConnection(_connectionString)){
        connection.Execute(query, new { pnombreUsuario=inte.nombreUsuario,  pcontrasenia=inte.contrasenia,pDNI=inte.DNI, pnombreCompleto=inte.mombreCompleto, pfechaNacimiento=inte.fechaNacimiento, pcancionFav=inte.cancionFav,pmateriaFav=inte.materiaFav });
        }
                
    }
     public List<Integrante> levantarIntegrantes(){

   
        List<Integrante> integrantes= new List<Integrante>();
        using(SqlConnection connection = new SqlConnection(_connectionString)){
 
        string query = "SELECT * FROM Integrantes";
        integrantes= connection.Query<Integrante>(query).ToList();
            
        }
        return integrantes;
   }

}
