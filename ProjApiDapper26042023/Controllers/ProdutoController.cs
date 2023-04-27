using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjApiDapper26042023.Models;
using ProjApiDapper26042023.Services;

namespace ProjApiDapper26042023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private ProdutoService _produtoService;

        public ProdutoController()
        {
            _produtoService = new ProdutoService();
        }

        [HttpGet]
        public ActionResult<List<Produto>> Listar() => _produtoService.Listar();

        [HttpGet("{id}", Name = "ConsultarProdutoPorId")]
        public ActionResult<Produto> ConsultarPorId(int id) => _produtoService.ConsultarPorId(id);

        [HttpPost]
        public Produto Inserir(Produto produto) => _produtoService.Inserir(produto);

        [HttpPut]
        public bool Atualizar(Produto produto) => _produtoService.Atualizar(produto);

        [HttpDelete]
        public bool Deletar(int id) => _produtoService.Deletar(id);
       
    }
}
