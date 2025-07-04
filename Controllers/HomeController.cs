using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TPBDPROG.Models;

namespace TPBDPROG.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult iniciarSesion(string estado){
            ViewBag.estado=estado;
        return View();
    }

    public IActionResult comprobarDatos(string nombreUsuarioIntento, string contraseniaIntento){
                List<Integrante> integrantes= new List<Integrante>();
          foreach(Integrante inte in BD.levantarIntegrantes()){
            integrantes.Add(inte);
          }
        int posicionUsuario=buscarNombreUsuario(integrantes,nombreUsuarioIntento);
        if(posicionUsuario<integrantes.Count){
            if(integrantes[posicionUsuario].comprobarContrasenia(contraseniaIntento)){
                return RedirectToAction("vistaUsuario",integrantes[posicionUsuario]);
            }else{
                return RedirectToAction("iniciarSesion",new{estado="contraseniaIncorrecta"});
            }
        }
        return RedirectToAction("iniciarSesion",new{estado="usuarioNoEncontrado"});
    }
    
    private int buscarNombreUsuario(List<Integrante> integrantes, string nombreUsuarioIntento){
        int i=0;
        bool encontrado=false;
                while(!encontrado && i<integrantes.Count){
            if(integrantes[i].nombreUsuario==nombreUsuarioIntento){
                encontrado=true;
            }else{
                i++;
            }
        }
        return i;
    }
    public IActionResult vistaUsuario(Integrante integrante){
        ViewBag.Usuario=integrante.nombreUsuario;
        ViewBag.DNI=integrante.DNI;
        ViewBag.nombre=integrante.nombreCompleto;
        ViewBag.edad=integrante.ObtenerEdad(integrante.fechaNacimiento);
        ViewBag.cancion=integrante.cancionFav;
        ViewBag.materia=integrante.materiaFav;
        return View();
    }

    public IActionResult registrarse(string estado){
        ViewBag.estado=estado;
        return View();
    }

      public IActionResult registrarNuevo(string nombreUsuarioNuevo,string contrasenia, string DNI,string NombreCompleto,DateTime fechaNacimiento,string cancion, string materia){
          Integrante inte=new Integrante();
          List<Integrante> integrantes= new List<Integrante>();
          foreach(Integrante integ in BD.levantarIntegrantes()){
            integrantes.Add(integ);
          }

         int posicionUsuario=buscarNombreUsuario(integrantes,nombreUsuarioNuevo);

        if(posicionUsuario<integrantes.Count){
            return RedirectToAction("registrarse","errorUsuario");
        }else{
            inte.crearIntegrante(nombreUsuarioNuevo,contrasenia,DNI,NombreCompleto,fechaNacimiento,cancion,materia);
            integrantes.Add(inte);
            BD.agregarIntegrante(integrantes[integrantes.Count-1]);
            return RedirectToAction("registrarse","funciono");
        }
    }
}
