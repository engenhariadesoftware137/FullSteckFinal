using Dominio;
using Repositorio;

namespace Servico
{
    public class EstudanteServico : IEstudanteServico
    {
        private readonly IEstudanteRepositorio _repositorio;

        public EstudanteServico(IEstudanteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void AdicionarEstudante(Estudante estudante)
        {
            // Aqui você pode adicionar regras de negócio antes de salvar
            // Ex: if(estudante.Nota < 0) throw new Exception("Nota inválida");
            _repositorio.Adicionar(estudante);
        }

        public List<Estudante> ListarTodos()
        {
            return _repositorio.ListarTodos();
        }

        public Estudante ObterPorId(int id)
        {
            return _repositorio.ObterPorId(id);
        }

        public void AtualizarEstudante(Estudante estudante)
        {
            // Aqui também podem ir regras de negócio
            _repositorio.Atualizar(estudante);
        }

        public void RemoverEstudante(int id)
        {
            // Ex: Validar se o estudante pode ser removido
            _repositorio.Remover(id);
        }
    }
}
