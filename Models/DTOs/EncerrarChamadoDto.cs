using System.ComponentModel.DataAnnotations;

namespace DeskFlowAPI.Models.DTOs
{
    public class EncerrarChamadoDto
    {
        [Required]
        [StringLength(1000)]
        public string Solucao { get; set; } = string.Empty;
    }
}