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
    public class EstoqueRepository : IEstoqueRepository
    {
        private string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=D:\bancoAula\dbLoja.mdf;";

        public bool Atualizar(Estoque estoque)
        {
            var status = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Execute(Estoque.ATUALIZAR, estoque);
                status = true;
            }
            return status;
        }

        public Estoque ConsultarPorId(int id)
        {
            using (var db = new SqlConnection(_conn))
            {
                var e = db.Query<Estoque, Produto, Tipo, Estoque>(Estoque.CONSULTAR, (estoque, produto, tipo) =>
                {
                    estoque.Produto = produto;
                    estoque.Produto.Tipo = tipo;
                    return estoque;
                }, splitOn: "IdProduto, IdTipo");
                return e.First();
            }

            //var estoque = db.QueryFirstOrDefault<Estoque>(Estoque.CONSULTARPORID, new { @IdEstoque = id });
            //return (Estoque)estoque;
        }

        public bool Deletar(int id)
        {
            var status = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Execute(Estoque.DELETAR, new { @IdEstoque = id }); ;
                status = true;
            }
            return status;
        }

        public Estoque Inserir(Estoque estoque)
        {
            var idEstoque = 0;

            using (var db = new SqlConnection(_conn))
            {
                idEstoque = db.ExecuteScalar<int>(Estoque.INSERIR, new { @Descricao = estoque.Descricao,
                                                                         @IdProduto = estoque.Produto.IdProduto});
            }
            estoque.IdEstoque = idEstoque;
            return estoque;
        }

        public List<Estoque> Listar()
        {
            using (var db = new SqlConnection(_conn))
            {
                // var lst = db.Query<Estoque>(Estoque.CONSULTAR);
                // return (List<Estoque>)lst;

                var estoques = db.Query<Estoque, Produto, Tipo, Estoque>(Estoque.CONSULTAR, (estoque, produto, tipo) =>
                {
                    estoque.Produto = produto;
                    estoque.Produto.Tipo = tipo;
                    return estoque;
                }, splitOn: "IdProduto, IdTipo");
                return (List<Estoque>)estoques;
            }
        }
    }
}
