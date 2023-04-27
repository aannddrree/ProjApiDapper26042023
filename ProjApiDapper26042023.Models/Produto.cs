using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjApiDapper26042023.Models
{
    public class Produto
    {

        public readonly static string INSERIR = "insert into Produto (Nome, Qtd, IdTipo) values (@Nome, @Qtd, @IdTipo); select cast(scope_identity() as int)";
        public readonly static string ATUALIZAR = "update Produto set Nome = @Nome, Qtd = @Qtd, IdProduto = @IdProduto where IdProduto = @IdProduto";
        public readonly static string DELETAR = "delete from Produto where IdProduto = @IdProduto";
        public readonly static string CONSULTAR = "select p.IdProduto, p.Nome, p.Qtd, p.IdTipo, t.Descricao from Produto p inner join Tipo t on p.IdTipo = t.IdTipo";
        public readonly static string CONSULTARPORID = "select p.IdProduto, p.Nome, p.Qtd, p.IdTipo, t.Descricao from Produto p inner join Tipo t on p.IdTipo = t.IdTipo where IdProduto = @IdProduto";

        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public int Qtd { get; set; }
        public Tipo Tipo { get; set; }
    }
}
