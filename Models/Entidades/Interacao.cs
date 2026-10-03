using System.Text.Json.Serialization;

namespace DeskFlowAPI.Models.Entidades

{
//     Interacao: o histórico de conversa dentro do chamado

// Um chamado raramente é resolvido de uma vez. Durante o atendimento, o suporte vai anotando o que descobriu, pedindo informações, avisando o que já tentou. Cada uma dessas anotações é uma Interacao.

// Exemplo real de um chamado "Computador não liga":

// Chamado #5 (Hardware, Alta, Maria Souza)
//  │
//  ├─ Interacao 1 | Carlos (suporte): "Verifiquei remotamente, sem resposta."
//  ├─ Interacao 2 | Carlos (suporte): "Vou passar na sua mesa às 14h."
//  └─ Interacao 3 | Carlos (suporte): "Era o cabo de energia. Resolvido."
    
    public class Interacao
    {
        public int Id { get; set; }

        public string Autor { get; set; } = string.Empty;

        public string Mensagem { get; set; } = string.Empty;

        public DateTime DataRegistro { get; set; }

        public int ChamadoId { get; set; }

        [JsonIgnore]
        public Chamado Chamado { get; set; } = null!;
    }
}