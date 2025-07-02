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

    public IActionResult iniciarSesion(){
        return View();
    }

    public IActionResult comprobarDatos(string nombreUsuarioIntento, string contraseniaIntento){
        bool encontrado=false;
        int i=0;
         List<Integrante> integrantes=BD.levantarIntegrantes();
        while(!encontrado && i<integrantes.Count){
            if(integrantes[i].nombreUsuario==nombreUsuarioIntento){
                encontrado=true;
            }else{
                i++;
            }
        }
        if(encontrado){
            if(integrantes[i].contrasenia==contraseniaIntento){
                return RedirectToAction("vistaUsuario",integrantes[i]);
            }else{
                return View("iniciarSesion");
            }
        }
        return View();
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
          List<Integrante> integrantes=BD.levantarIntegrantes();
       bool encontrado=integrantes.nombreUsuario.Contains(nombreUsuarioNuevo);
        if(encontrado){
            return RedirectToAction("registrarse","errorUsuario");
        }else{
            BD.crearIntegrante(nombreUsuarioNuevo,contrasenia,DNI,NombreCompleto,fechaNacimiento,cancion,materia);
            return RedirectToAction("registrarse","funciono");

        }
    }
}
