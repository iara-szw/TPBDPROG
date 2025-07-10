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
        List<Integrante> integrantes = BD.levantarIntegrantes();
        int posicionUsuario=buscarNombreUsuario(nombreUsuarioIntento);
        string passHasheada = encriptar.HashearPassword(contraseniaIntento);
        if(posicionUsuario !=-1){
            if(integrantes[posicionUsuario].password == passHasheada){
                return RedirectToAction("vistaUsuario",integrantes[posicionUsuario]);
            }else{
                return RedirectToAction("iniciarSesion",new{estado="contraseniaIncorrecta"});
            }
        }
        return RedirectToAction("iniciarSesion",new{estado="usuarioNoEncontrado"});
    }
    
    private int buscarNombreUsuario(string nombreUsuarioIntento){
         List<Integrante> integrantes = BD.levantarIntegrantes();
        bool encontrado=false;
                for(int i=0;i<integrantes.Count;i++){
            if(integrantes[i].nombreUsuario==nombreUsuarioIntento){
                return i;
            }
        }
        return -1;
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

      public IActionResult registrarNuevo(string nombreUsuarioNuevo,string password, string DNI,string NombreCompleto,DateTime fechaNacimiento,string cancion, string materia){
        Integrante inte=new Integrante();
         int posicionUsuario=buscarNombreUsuario(nombreUsuarioNuevo);
        if(posicionUsuario!=-1){
            return RedirectToAction("registrarse", new{ estado="errorUsuario"});
        }else{
            string passwordHasheada = encriptar.HashearPassword(password);
            inte.crearIntegrante(nombreUsuarioNuevo, passwordHasheada, DNI, NombreCompleto, fechaNacimiento, cancion, materia);
            BD.agregarIntegrante(inte);
            if(buscarNombreUsuario(nombreUsuarioNuevo)==-1){
                 return RedirectToAction("registrarse", new{estado="Nofunciono"});
            }
            return RedirectToAction("registrarse",new{estado="funciono"});
        }
    }
}
