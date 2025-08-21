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
        if (HttpContext.Session.GetString("Usuario") != null)
        {
            List<Tarea> listaTareas = new List<Tarea>();
            int user = int.Parse(HttpContext.Session.GetString("Usuario"));
            listaTareas = BD.verTareas(user);
            ViewBag.listaTareas = listaTareas;
            return View();

        }
        else {
            return RedirectToAction("Registro", "Account");
        }
    }

	public IActionResult GuardarTarea (int IDTarea, string titulo, string descripcion, bool finalizada, bool direccion){
        int user = int.Parse(HttpContext.Session.GetString("Usuario"));
        if (!direccion){
            BD.modificarTarea(IDTarea, titulo, descripcion, DateTime.Now, finalizada, user);
        }
        else{
            BD.nuevaTarea(titulo, descripcion, DateTime.Now, finalizada, user);
        }
        List<Tarea> listaTareas = new List<Tarea>();
        listaTareas = BD.verTareas(user);
        ViewBag.listaTareas = listaTareas;
        return View ("VerTareas");
    }
	public IActionResult EliminarTarea (int IDTarea){
        BD.eliminarTarea(IDTarea);
        List<Tarea> listaTareas = new List<Tarea>();
        int user = int.Parse(HttpContext.Session.GetString("Usuario"));
        listaTareas = BD.verTareas(user);
        ViewBag.listaTareas = listaTareas;
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
        List<Tarea> listaTareas = new List<Tarea>();
        int user = int.Parse(HttpContext.Session.GetString("Usuario"));
        listaTareas = BD.verTareas(user);
        ViewBag.listaTareas = listaTareas;
        return View ("VerTareas");
    }



}
