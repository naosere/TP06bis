using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06Bis_SV.Models;

namespace TP06Bis_SV.Controllers;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View("Login");
    }

    [HttpPost]
    public IActionResult LoginGuardar(string username, string contraseña)
    {   
        ViewBag.mensajeError = "";
        string devolver = "Login";
        Usuario usuario = BD.Login(username, contraseña);
        if(usuario != null){
        devolver = "Index";
        HttpContext.Session.SetString("Usuario", usuario.IDUsuario.ToString()); 
        }else{
            ViewBag.mensajeError = "Usuario o clave incorrecto";
        }
        return View(devolver);
    }
    public IActionResult Registro()
    {
        return View("Registrarse");
    }
    [HttpPost]
    public IActionResult RegistroGuardar(string nombre, string apellido, string usuario, string contraseña, string confirmarContraseña)
    {
        string prueba = "PRUEBA";
        string devolver = "Registrarse";
        if (contraseña != confirmarContraseña){
            ViewBag.mensajeError = "LAS CONTRASEÑAS NO COINCIDEN";}
        else{
        BD.Registro(nombre, apellido, usuario, contraseña, prueba, (DateTime.Now));
        Usuario aux = new Usuario();
        aux = BD.Login (usuario, contraseña);
        HttpContext.Session.SetString("Usuario", aux.ToString()); 
        devolver = "VerTareas";
        }

        return View(devolver);
    }
}
