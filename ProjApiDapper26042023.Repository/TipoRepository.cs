using Dapper;
using ProjApiDapper26042023.Models;
using System.Data.SqlClient;

namespace ProjApiDapper26042023.Repositories
{
    public class TipoRepository : ITipoRepository
    {

        private string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=D:\bancoAula\dbLoja.mdf;";

        public bool Atualizar(Tipo tipo)
        {
            var status = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Execute(Tipo.ATUALIZAR, tipo);
                status = true;
            }
            return status;
        }

        public Tipo ConsultarPorId(int id)
        {
            using (var db = new SqlConnection(_conn))
            {
                var tipo = db.QueryFirstOrDefault<Tipo>(Tipo.CONSULTARPORID, new { @IdTipo = id });
                return (Tipo)tipo;
            }
        }

        public bool Deletar(int id)
        {
            var status = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Execute(Tipo.DELETAR, new { @IdTipo = id }); ;
                status = true;
            }
            return status;
        }

        public Tipo Inserir(Tipo tipo)
        {
            var idTipo = 0;

            using (var db = new SqlConnection(_conn))
            {
                idTipo = db.ExecuteScalar<int>(Tipo.INSERIR, tipo);
            }
            tipo.IdTipo = idTipo;
           return tipo;
        }

        public List<Tipo> Listar()
        {
            using (var db = new SqlConnection(_conn))
            {
                var lst = db.Query<Tipo>(Tipo.CONSULTAR);
                return (List<Tipo>) lst;
            }
        }
    }
}