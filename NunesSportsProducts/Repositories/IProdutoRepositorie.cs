using NunesSportsProducts.Models;

namespace NunesSportsProducts.Repositories
{
    public interface IProdutoRepositorie
    {

        List<ProdutoModel> BuscarTodos();

        ProdutoModel Adicionar(ProdutoModel produto);

        ProdutoModel BuscarPorId(int id);

        ProdutoModel Editar(ProdutoModel produto);


        bool Apagar(int id);

    }
}
