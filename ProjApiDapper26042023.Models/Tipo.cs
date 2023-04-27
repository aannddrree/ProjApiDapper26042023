using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjApiDapper26042023.Models
{
    public class Tipo
    {

        public readonly static string INSERIR = "insert into Tipo (Descricao) values (@Descricao); select cast(scope_identity() as int)";
        public readonly static string ATUALIZAR = "update Tipo set Descricao = @Descricao where IdTipo = @IdTipo";
        public readonly static string DELETAR = "delete from Tipo where IdTipo = @IdTipo";
        public readonly static string CONSULTAR = "select IdTipo, Descricao from Tipo";
        public readonly static string CONSULTARPORID = "select IdTipo, Descricao from Tipo where IdTipo = @IdTipo";


        public int IdTipo { get; set; }
        public string Descricao { get; set; }
    }
}
