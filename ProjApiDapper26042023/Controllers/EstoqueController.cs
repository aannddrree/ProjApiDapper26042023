using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjApiDapper26042023.Models;
using ProjApiDapper26042023.Services;

namespace ProjApiDapper26042023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private EstoqueService _estoqueService;
        private TipoService _tipoService;
        private ProdutoService _produtoService;

        public EstoqueController()
        {
            _estoqueService = new EstoqueService();
            _tipoService = new TipoService();
            _produtoService = new ProdutoService();
        }

        [HttpGet]
        public ActionResult<List<Estoque>> Listar() => _estoqueService.Listar();

        [HttpGet("{id}", Name = "ConsultarEstoquePorId")]
        public ActionResult<Estoque> ConsultarPorId(int id) => _estoqueService.ConsultarPorId(id);

        [HttpPost]
        public Estoque Inserir(Estoque estoque)
        {
            estoque.Produto.Tipo = (estoque.Produto.Tipo.IdTipo == 0) ? _tipoService.Inserir(estoque.Produto.Tipo) : _tipoService.ConsultarPorId(estoque.Produto.Tipo.IdTipo);
            estoque.Produto = (estoque.Produto.IdProduto == 0) ? _produtoService.Inserir(estoque.Produto) : _produtoService.ConsultarPorId(estoque.Produto.IdProduto);
            return _estoqueService.Inserir(estoque);
        } 

        [HttpPut]
        public bool Atualizar(Estoque estoque) => _estoqueService.Atualizar(estoque);

        [HttpDelete]
        public bool Deletar(int id) => _estoqueService.Deletar(id);
    }
}
