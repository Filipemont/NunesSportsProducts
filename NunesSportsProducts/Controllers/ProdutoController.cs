using Microsoft.AspNetCore.Mvc;
using NunesSportsProducts.Models;
using NunesSportsProducts.Repositories;

namespace NunesSportsProducts.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorie _produtoRepositorie;

        public ProdutoController(IProdutoRepositorie produtoRepositorie)
        {
            _produtoRepositorie = produtoRepositorie;
        }

        public IActionResult Index()
        {
            var produtos = _produtoRepositorie.BuscarTodos();
            return View(produtos);
        }
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ProdutoModel produto)
        {
            _produtoRepositorie.Adicionar(produto);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            ProdutoModel produto = _produtoRepositorie.BuscarPorId(id);
            return View(produto);
        }

        [HttpPost]
        public IActionResult Editar(ProdutoModel produto)
        {
            _produtoRepositorie.Editar(produto);
            return RedirectToAction("Index");
        }

        public IActionResult Detalhes(int id)
        {
            ProdutoModel produto = _produtoRepositorie.BuscarPorId(id);
            return View(produto);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ProdutoModel produto = _produtoRepositorie.BuscarPorId(id);
            return View(produto);
        }

        public IActionResult Apagar(int id)
        {
            _produtoRepositorie.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}
