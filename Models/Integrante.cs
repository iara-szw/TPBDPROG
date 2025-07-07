public class Integrante{
    public string nombreUsuario{get; set;}
    public string password{get; set;}
    public string DNI{get; set;}
    public string nombreCompleto{get; set;}
    public DateTime fechaNacimiento{get; set;}
    public string cancionFav{get;set;}
    public string materiaFav{get;set;}

    public void crearIntegrante(string NombreUsuario,string Password, string dni, string NombreCompleto,DateTime nacimiento,string Cancion,string Materia){
        nombreUsuario=NombreUsuario;
        password=Password;
        DNI=dni;
        nombreCompleto=NombreCompleto;
        fechaNacimiento=nacimiento;
        cancionFav=Cancion;
        materiaFav=Materia;
    }


        public int ObtenerEdad(DateTime nacimiento){
        return DateTime.Today.Year - nacimiento.Year;
       }

}