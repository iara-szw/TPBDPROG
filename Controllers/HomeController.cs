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

    public IActionResult comprobarDatos(string nombreUsuarioNuevo, string password){
       Integrante integrante = BD.levantarIntegrante(nombreUsuarioNuevo,encriptar.HashearPassword(password));
            if(integrante != null){
                return RedirectToAction("vistaUsuario",integrante);
            }else{
                return RedirectToAction("iniciarSesion",new{estado="Error"});
            }
    }
    
    public IActionResult vistaUsuario(Integrante integrante){
        ViewBag.Usuario=integrante.nombreUsuario;
        ViewBag.DNI=integrante.DNI;
        ViewBag.nombre=integrante.nombreCompleto;
        ViewBag.edad=integrante.ObtenerEdad(integrante.fechaNacimiento);
        ViewBag.cancion=integrante.cancionFav;
        ViewBag.libro=integrante.libroFav;
        return View();
    }

    public IActionResult registrarse(string estado){
        ViewBag.estado=estado;
        return View();
    }

      public IActionResult registrarNuevo(string nombreUsuarioNuevo,string password, string DNI,string nombreCompleto,DateTime fechaNacimiento,string cancionFav, string libroFav){
        if(BD.yaExiste(nombreUsuarioNuevo)){
            return RedirectToAction("registrarse", new{ estado="errorUsuario"});
        }else{
            Integrante inte=new Integrante();
            string passwordHasheada = encriptar.HashearPassword(password);
            inte.crearIntegrante(nombreUsuarioNuevo, passwordHasheada, DNI, nombreCompleto, fechaNacimiento, cancionFav, libroFav);
            BD.agregarIntegrante(inte);
            if(!BD.yaExiste(nombreUsuarioNuevo)){
                 return RedirectToAction("registrarse", new{estado="Nofunciono"});
            }
            return RedirectToAction("registrarse",new{estado="funciono"});
        }
    }
}
