using ProjApiDapper26042023.Models;
using ProjApiDapper26042023.Repositories;

namespace ProjApiDapper26042023.Services
{
    public class TipoService 
    {
        private ITipoRepository tipoRepository;

        public TipoService()
        {
            tipoRepository = new TipoRepository();
        }

        public Tipo Inserir(Tipo tipo)
        {
            return tipoRepository.Inserir(tipo);
        }

        public bool Atualizar(Tipo tipo)
        {
            return tipoRepository.Atualizar(tipo);
        }

        public bool Deletar(int id)
        {
            return tipoRepository.Deletar(id);
        }

        public List<Tipo> Listar()
        {
            return tipoRepository.Listar();
        }

        public Tipo ConsultarPorId(int id)
        {
            return tipoRepository.ConsultarPorId(id);
        }
    }
}