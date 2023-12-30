using NunesSportsProducts.Data;
using NunesSportsProducts.Models;

namespace NunesSportsProducts.Repositories
{
    public class ProdutoRepositorie : IProdutoRepositorie
    {
        private readonly BancoContext _bancoContext;

        public ProdutoRepositorie(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ProdutoModel> BuscarTodos()
        {
            return _bancoContext.Produtos.ToList();
        }

        public ProdutoModel BuscarPorId(int id)
        {
            return _bancoContext.Produtos.FirstOrDefault(x => x.Id == id);
        }

        public ProdutoModel Adicionar(ProdutoModel produto)
        {
           _bancoContext.Produtos.Add(produto);
           _bancoContext.SaveChanges();
           return produto;
        }

        public ProdutoModel Editar(ProdutoModel produto)
        {
            ProdutoModel produtoDb = BuscarPorId(produto.Id);

            if(produtoDb == null)
            {
                throw new Exception("Houve um erro na atualização do produto");
            }

            produtoDb.Nome = produto.Nome;
            produtoDb.Preco = produto.Preco;
            produtoDb.DescricaoCurta = produto.DescricaoCurta;
            produtoDb.DescricaoCompleta = produto.DescricaoCompleta;

            _bancoContext.Produtos.Update(produtoDb);
            _bancoContext.SaveChanges();
            return produtoDb;
        }

        public bool Apagar(int id)
        {
            ProdutoModel produtoDb = BuscarPorId(id);

            if (produtoDb == null)
            {
                throw new Exception("Houve um erro na deleção do produto");
            }


            _bancoContext.Produtos.Remove(produtoDb);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
