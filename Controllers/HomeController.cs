using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06Bis_SV.Models;

namespace TP06Bis_SV.Controllers;

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

	public IActionResult VerTareas(){
        List<Tarea> listaTareas = new List<Tarea>();
        string IDUsuario = HttpContext.Session.GetString("Usuario");
        if (IDUsuario != null){
        listaTareas = BD.verTareas(int.Parse(IDUsuario));
        ViewBag.listaTareas = listaTareas;
        return View();
        }
        else {
            return View("Registrarse");
        }
    }
	public IActionResult NuevaTarea (/*formulario para que cargue las tareas*/){
        return View();
    }

    [HttpPost]
    public IActionResult NuevaTareaGuardar (string titulo, string descripcion, DateTime fecha, bool finalizada, int IDUsuario){
        BD.nuevaTarea(titulo, descripcion, fecha, finalizada, (int.Parse(HttpContext.Session.GetString("Usuario"))));
        return View ("VerTareas");
    }

	public IActionResult ModificarTarea(){
        return View();
    }
	public IActionResult ModificarTareaGuardar (atributos de la tabla tareas){

    }
	public IActionResult EliminarTarea (int IDTarea){
        BD.eliminarTarea(IDTarea);
        return View("VerTareas");
    }
	public IActionResult FinalizarTarea(int IDTarea){
        Tarea aux = new Tarea();
        aux = BD.verTarea(IDTarea);
        bool finalizada = true;
        if (aux.finalizada){
            BD.finalizarTarea(IDTarea,finalizada);
        }
        else{
            finalizada = false;
            BD.finalizarTarea(IDTarea,finalizada);
        }
        return View ("VerTareas");
    }



}
