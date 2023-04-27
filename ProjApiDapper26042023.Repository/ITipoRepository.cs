using ProjApiDapper26042023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjApiDapper26042023.Repositories
{
    public interface ITipoRepository
    {
        Tipo Inserir(Tipo tipo);
        bool Atualizar(Tipo tipo);
        bool Deletar(int id);
        List<Tipo> Listar();
        Tipo ConsultarPorId(int id);
    }
}
