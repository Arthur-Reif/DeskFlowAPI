using System.ComponentModel.DataAnnotations;

namespace DeskFlowAPI.Models.DTOs
{
    public class CriarInteracaoDto
    {
        [Required]
        [StringLength(100)]
        public string Autor { get; set; } = string.Empty;

        [Required]
        [StringLength(1000)]
        public string Mensagem { get; set; } = string.Empty;
    }
}