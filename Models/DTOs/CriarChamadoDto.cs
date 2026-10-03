using System.ComponentModel.DataAnnotations;
using DeskFlowAPI.Models.Entidades;

namespace DeskFlowAPI.Models.DTOs
{
    public class CriarChamadoDto
    {
        [Required]
        [StringLength(200)]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        [StringLength(1000)]
        public string Descricao { get; set; } = string.Empty;

        [Required]
        public Prioridade? Prioridade { get; set; }

        [Required]
        [StringLength(200)]
        public string SolicitanteNome { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int CategoriaId { get; set; }
    }
}