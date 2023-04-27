using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjApiDapper26042023.Models;
using ProjApiDapper26042023.Services;

namespace ProjApiDapper26042023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {

        private TipoService _tipoService;

        public TipoController()
        {
            _tipoService = new TipoService();
        }

        [HttpGet]
        public List<Tipo> Listar() => _tipoService.Listar();

        [HttpGet ("{id}", Name = "ConsultarTipoPorId")]
        public ActionResult<Tipo> ConsultarPorId(int id) => _tipoService.ConsultarPorId(id);

        [HttpPost]
        public Tipo Inserir(Tipo tipo) => _tipoService.Inserir(tipo);

        [HttpPut]
        public bool Atualizar(Tipo tipo) => _tipoService.Atualizar(tipo);

        [HttpDelete]
        public bool Deletar(int id) => _tipoService.Deletar(id);
    }
}
