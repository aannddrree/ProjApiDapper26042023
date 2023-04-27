using ProjApiDapper26042023.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ProjApiDapper26042023.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=D:\bancoAula\dbLoja.mdf;";

        public bool Atualizar(Produto produto)
        {
            var status = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Execute(Produto.ATUALIZAR, produto);
                status = true;
            }
            return status;
        }

        public Produto ConsultarPorId(int id)
        {
            using (var db = new SqlConnection(_conn))
            {

                var p = db.Query<Produto, Tipo, Produto>(Produto.CONSULTAR, (produto, tipo) =>
                {
                    produto.Tipo = tipo;
                    return produto;
                }, splitOn: "IdTipo");
                return p.First();

                // var produto = db.QueryFirstOrDefault<Produto>(Produto.CONSULTARPORID, new { @IdProduto = id });
                // return (Produto)produto;
            }
        }

        public bool Deletar(int id)
        {
            var status = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Execute(Produto.DELETAR, new { @IdProduto = id }); ;
                status = true;
            }
            return status;
        }

        public Produto Inserir(Produto produto)
        {
            var idProduto = 0;

            using (var db = new SqlConnection(_conn))
            {
                idProduto = db.ExecuteScalar<int>(Produto.INSERIR, new { @Nome = produto.Nome, 
                                                                         @Qtd = produto.Qtd,
                                                                         @IdTipo = produto.Tipo.IdTipo});
            }
            produto.IdProduto = idProduto;
            return produto;
        }

        public List<Produto> Listar()
        {
            using (var db = new SqlConnection(_conn))
            {
                var produtos = db.Query<Produto, Tipo, Produto>(Produto.CONSULTAR, (produto, tipo) =>
                {
                    produto.Tipo = tipo;
                    return produto;
                }, splitOn: "IdTipo");
                return (List<Produto>)produtos;

                //var lst = db.Query<Produto>(Produto.CONSULTAR);
                //return (List<Produto>)lst;
            }
        }
    }
}
