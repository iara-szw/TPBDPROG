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

        if (HttpContext.Session.GetString("integrante") != null)
        {
            return RedirectToAction("vistaUsuario");
            }

        return View();
    }

    public IActionResult comprobarDatos(string nombreUsuarioNuevo, string password){
       Integrante integrante = BD.levantarIntegrante(nombreUsuarioNuevo,encriptar.HashearPassword(password));
            if(integrante != null){
                HttpContext.Session.SetString("integrante", Objeto.ObjectToString(integrante));
                return RedirectToAction("vistaUsuario");
            }else{
                return RedirectToAction("iniciarSesion",new{estado="error"});
            }
    }
    
    public IActionResult vistaUsuario(){
        Integrante integrante= Objeto.StringToObject<Integrante>(HttpContext.Session.GetString("integrante"));
        if (integrante != null)
        {
            ViewBag.Usuario = integrante.nombreUsuario;
            ViewBag.DNI = integrante.DNI;
            ViewBag.nombre = integrante.nombreCompleto;
            ViewBag.edad = integrante.ObtenerEdad(integrante.fechaNacimiento);
            ViewBag.cancion = integrante.cancionFav;
            ViewBag.libro = integrante.libroFav;
            return View();
        }

        return RedirectToAction("index");
    }

    public IActionResult cerrarSesion(){
        HttpContext.Session.Remove("integrante");
        return RedirectToAction("iniciarSesion");
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
            return RedirectToAction("registrarse",new{estado="funciono"});
        }
    }
}
