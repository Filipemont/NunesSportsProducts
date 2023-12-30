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
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoRepositorie.Adicionar(produto);
                    TempData["MensagemSucesso"] = "Produto cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(produto);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar o produto! {ex.Message}";
                return RedirectToAction("Index");
            }

        }

        public IActionResult Editar(int id)
        {
            ProdutoModel produto = _produtoRepositorie.BuscarPorId(id);
            return View(produto);
        }

        [HttpPost]
        public IActionResult Editar(ProdutoModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoRepositorie.Editar(produto);
                    TempData["MensagemSucesso"] = "Produto alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(produto);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao atualizar o produto! {ex.Message}";
                return RedirectToAction("Index");
            }
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
            try
            {
                bool apagado = _produtoRepositorie.Apagar(id);

                if (apagado == true)
                {
                    TempData["MensagemSucesso"] = "Produto apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Produto não foi apagado";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Produto não foi apagado! {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
