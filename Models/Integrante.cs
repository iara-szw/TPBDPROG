public class Integrante{
    public string nombreUsuario{get; set;}
    public string contrasenia{private get; set;}
    public string DNI{get; set;}
    public string nombreCompleto{get; set;}
    public DateTime fechaNacimiento{get; set;}
    public string cancionFav{get;set;}
    public string materiaFav{get;set;}

    public void crearIntegrante(string NombreUsuario,string Contrasenia, string dni, string NombreCompleto,DateTime nacimiento,string CancionFav,string MateriaFav){
        nombreUsuario=NombreUsuario;
        contrasenia=Contrasenia;
        DNI=dni;
        nombreCompleto=NombreCompleto;
        fechaNacimiento=nacimiento;
        cancionFav=CancionFav;
        materiaFav=MateriaFav;
    }


        public int ObtenerEdad(DateTime nacimiento){
        return DateTime.Today.Year - nacimiento.Year;
       }

}