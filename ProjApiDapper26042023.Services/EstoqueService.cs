using ProjApiDapper26042023.Models;
using ProjApiDapper26042023.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjApiDapper26042023.Services
{
    public class EstoqueService
    {
        private IEstoqueRepository estoqueRepository;

        public EstoqueService()
        {
            estoqueRepository = new EstoqueRepository();
        }

        public Estoque Inserir(Estoque estoque)
        {
            return estoqueRepository.Inserir(estoque);
        }

        public bool Atualizar(Estoque estoque)
        {
            return estoqueRepository.Atualizar(estoque);
        }

        public bool Deletar(int id)
        {
            return estoqueRepository.Deletar(id);
        }

        public List<Estoque> Listar()
        {
            return estoqueRepository.Listar();
        }

        public Estoque ConsultarPorId(int id)
        {
            return estoqueRepository.ConsultarPorId(id);
        }
    }
}
