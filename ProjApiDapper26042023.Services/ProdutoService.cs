using ProjApiDapper26042023.Models;
using ProjApiDapper26042023.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjApiDapper26042023.Services
{
    public class ProdutoService
    {
        private IProdutoRepository produtoRepository;

        public ProdutoService()
        {
            produtoRepository = new ProdutoRepository();
        }

        public Produto Inserir(Produto produto)
        {
            return produtoRepository.Inserir(produto);
        }

        public bool Atualizar(Produto produto)
        {
            return produtoRepository.Atualizar(produto);
        }

        public bool Deletar(int id)
        {
            return produtoRepository.Deletar(id);
        }

        public List<Produto> Listar()
        {
            return produtoRepository.Listar();
        }

        public Produto ConsultarPorId(int id)
        {
            return produtoRepository.ConsultarPorId(id);
        }
    }
}
