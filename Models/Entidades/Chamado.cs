namespace DeskFlowAPI.Models.Entidades
{
//     Chamado: o pedido de ajuda em si

// É a classe principal. Cada vez que um funcionário tem um problema, vira um Chamado, com título, descrição, prioridade, quem pediu e em que etapa está (Aberto, EmAndamento ou Fechado). É ele que guarda a história completa: quando abriu, quando fechou e qual foi a solução.
    public class Chamado
    {
        public int Id {get; set;}
        public string Titulo {get; set;} = string.Empty;
        public string Descricao {get; set;} = string.Empty;
        public Prioridade Prioridade {get; set;} //implementar validaçao na services
        public StatusChamado Status {get; set;} //implementar validaçao na services
        public string SolicitanteNome {get; set;} = string.Empty;
        public DateTime DataAbertura {get; set;}
        public DateTime? DataFechamento {get; set;}
        public string? Solucao {get; set;}
        public int CategoriaId {get; set;}
        public Categoria Categoria {get; set;} = null!;
        public List<Interacao> Interacoes {get; set;} = new ();
    }
}