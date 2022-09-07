using System;
using System.Collections.Generic;
using LifeShare.Persistencia;
using System.Linq;
using System.Threading.Tasks;
using LifeShare.Models;
using Microsoft.AspNetCore.Mvc;

namespace LifeShare.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteContext _context;

        //Injeção de dependência pelo construtor
        public ClienteController(ClienteContext context)
        {
            _context = context;
        }

        //Método que cadastra no banco de dados POST
        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
            //Cadastrar no banco
            _context.Clientes.Add(cliente);
            _context.SaveChanges(); //commit
            //Mensagem de sucesso
            TempData["msg"] = "Cliente Cadastrado!";
            //Redirect 
            return RedirectToAction("Cadastrar");
        }

        //Criar o método que exibe o formulário de cadastro, criar tag helper, partial views
        [HttpGet] //http://localhost:1231/cliente/cadastrar
        public IActionResult Cadastrar()
        {
            return View(); //Abri a página /Views/cliente/Cadastrar.cshtml
        }

        //Listar todos os Clientes
        public IActionResult Index()
        {
            var lista = _context.Clientes.ToList();

            return View(lista);//enviar a lista para a view
        }

        //Método que recebe o id do Cliente e retorna a página de formulário com os dados
        [HttpGet]
        public IActionResult Editar(int Id)
        {
            //Pesquisar o Cliente pelo código
            var Cliente = _context.Clientes.Find(Id);
            return View(Cliente);  //Enviar o Cliente para a view
        }

        //Método que chama a model para atualizar os dados no banco de dados
        [HttpPost]
        public IActionResult Editar(Cliente Cliente)
        {
            //Atualizar o Cliente no banco
            //_context.Attach(Cliente).State = EntityState.Modified;
            _context.Clientes.Update(Cliente);
            //Commit
            _context.SaveChanges();
            //Mensagem de sucesso
            TempData["msg"] = "Cliente atualizada!";
            //Redirecionar para a listagem
            return RedirectToAction("Index");
        }

         //Método que recebe o id do cliente e aciona o model para remove-lo do banco
        [HttpPost]
        public IActionResult Remover(int Id)
        {
            //Pesquisar o Cliente pelo id
            var cliente = _context.Clientes.Find(Id);
            //Remover o Cliente
            _context.Clientes.Remove(cliente);
            //Commit
            _context.SaveChanges();
            //Mensagem
            TempData["msg"] = "Cliente Removida!";
            //Redirect para a página de listagem
            return RedirectToAction("Index");
        }

        //Método de pesquisa
        [HttpPost]
        public IActionResult Pesquisar(int ClienteId)
        {
            //Pesquisar a cliente por id
            var lista = _context.Clientes.ToList();
            var clientes = lista.Find(current => current.ClienteId == ClienteId);

            return View(clientes);
        }

        [HttpGet]
        public IActionResult Pesquisar()
        {

            return View();
        }

    }
}
