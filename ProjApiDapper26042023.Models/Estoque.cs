namespace ProjApiDapper26042023.Models
{
    public class Estoque
    {

        public readonly static string INSERIR = "insert into Estoque (Descricao, IdProduto) values (@Descricao, @IdProduto); select cast(scope_identity() as int)";
        public readonly static string ATUALIZAR = "update Estoque set Descricao = @Descricao, IdProduto = @IdProduto  where IdEstoque = @IdEstoque";
        public readonly static string DELETAR = "delete from Estoque where IdEstoque = @IdEstoque";
        public readonly static string CONSULTAR = "select e.IdEstoque, e.Descricao, p.IdProduto, p.Nome, p.Qtd,  p.IdTipo, t.Descricao from Estoque e inner join Produto p on e.IdProduto = p.IdProduto inner join Tipo t on p.IdTipo = t.IdTipo";
        public readonly static string CONSULTARPORID = "select e.IdEstoque, e.Descricao, p.IdProduto, p.Nome, p.Qtd,  p.IdTipo, t.Descricao from Estoque e inner join Produto p on e.IdProduto = p.IdProduto inner join Tipo t on p.IdTipo = t.IdTipo where e.IdEstoque = @IdEstoque";

        public int IdEstoque { get; set; }
        public string Descricao { get; set; }
        public Produto Produto { get; set; }
    }
}