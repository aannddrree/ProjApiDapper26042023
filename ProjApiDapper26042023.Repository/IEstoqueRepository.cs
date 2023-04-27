using ProjApiDapper26042023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjApiDapper26042023.Repositories
{
    public interface IEstoqueRepository
    {
        Estoque Inserir(Estoque estoque);
        bool Atualizar(Estoque estoque);
        bool Deletar(int id);
        List<Estoque> Listar();
        Estoque ConsultarPorId(int id);
    }
}
