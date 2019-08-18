using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCEntityCoreCrud.Models;

namespace MVCEntityCoreCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserDbContext _context;
        public HomeController(UserDbContext context)
        {
            _context = context;
        }
        User cliente = new User();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public void InserrirNovoUsuario(string nome, int idade)
        {
            cliente.Nome = nome;
            cliente.Idade = idade;
            _context.Users.Add(cliente);
            _context.SaveChanges();
        }
        [HttpGet]
        public IEnumerable<User> UsersList()
        {
            return _context.Users;

        }
        [HttpPost]
        public void DeletarRegistro(int id)
        {
            _context.Remove(_context.Users.Find(id));
            _context.SaveChanges();
        }
        [HttpGet]
        public User ReturUser(int id)
        {
            return _context.Users.Find(id);
        }
        [HttpPut]
        public void AlterarRegistro(int id,string nome, int idade)
        {
            var usuario = _context.Users.Find(id);
            usuario.Nome = nome;
            usuario.Idade = idade;
            _context.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }        
    }
}
