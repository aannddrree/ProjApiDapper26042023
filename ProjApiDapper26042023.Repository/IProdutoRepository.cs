using ProjApiDapper26042023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjApiDapper26042023.Repositories
{
    public interface IProdutoRepository
    {
        Produto Inserir(Produto produto);
        bool Atualizar(Produto produto);
        bool Deletar(int id);
        List<Produto> Listar();
        Produto ConsultarPorId(int id);
    }
}
