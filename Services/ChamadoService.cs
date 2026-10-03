using DeskFlowAPI.Models.DTOs;
using DeskFlowAPI.Models.Entidades;
using DeskFlowAPI.Repositories;
using DeskFlowAPI.Services.Interfaces;

namespace DeskFlowAPI.Services
{
    public class ChamadoServices : IChamadoServices
    {
        private readonly IChamadoRepository _chamadoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public ChamadoServices(
            IChamadoRepository chamadoRepository,
            ICategoriaRepository categoriaRepository)
        {
            _chamadoRepository = chamadoRepository;
            _categoriaRepository = categoriaRepository;
        }
        public async Task<List<Chamado>> ListarTodosAsync(StatusChamado? status, Prioridade? prioridade, int? categoriaId)
        {
            return await _chamadoRepository.ListarTodosAsync(status, prioridade, categoriaId);
        }
        public async Task<Chamado> ObterPorIdAsync(int id)
        {
            var chamado = await _chamadoRepository.ObterPorIdAsync(id);

            if (chamado is null)
            {
                throw new KeyNotFoundException("Chamado não encontrado.");
            }

                return chamado;
        }
        public async Task<Chamado> AdicionarAsync(CriarChamadoDto chamadoDto)
        {
            var categoria = await _categoriaRepository.ObterPorIdAsync(chamadoDto.CategoriaId);

            if (categoria is null)
            {
                throw new InvalidOperationException("Categoria informada não existe.");
            }

            var chamado = new Chamado
            {
                Titulo = chamadoDto.Titulo,
                Descricao = chamadoDto.Descricao,
                Prioridade = chamadoDto.Prioridade!.Value,
                SolicitanteNome = chamadoDto.SolicitanteNome,
                CategoriaId = chamadoDto.CategoriaId,

                Status = StatusChamado.Aberto,
                DataAbertura = DateTime.UtcNow
            };

            return await _chamadoRepository.AdicionarAsync(chamado);
        }
        public async Task IniciarAsync(int id)
        {
            var chamado = await _chamadoRepository.ObterPorIdAsync(id);

            if (chamado is null)
            {
                throw new KeyNotFoundException("Chamado não encontrado.");
            }

            if (chamado.Status != StatusChamado.Aberto)
            {
                throw new InvalidOperationException("Somente chamados abertos podem ser iniciados.");
            }

            chamado.Status = StatusChamado.EmAndamento;

            await _chamadoRepository.AtualizarAsync(chamado);
        }
        public async Task EncerrarAsync(int id, EncerrarChamadoDto chamadoDto)
        {
            var chamado = await _chamadoRepository.ObterPorIdAsync(id);

            if (chamado is null)
            {
                throw new KeyNotFoundException("Chamado não encontrado.");
            }

            if (chamado.Status != StatusChamado.EmAndamento)
            {
                throw new InvalidOperationException("Somente chamados em andamento podem ser encerrados.");
            }

            if (string.IsNullOrWhiteSpace(chamadoDto.Solucao))
            {
                throw new InvalidOperationException("A solução deve ser informada.");
            }

            chamado.Status = StatusChamado.Fechado;
            chamado.Solucao = chamadoDto.Solucao;
            chamado.DataFechamento = DateTime.UtcNow;

            await _chamadoRepository.AtualizarAsync(chamado);
        }
    }
}