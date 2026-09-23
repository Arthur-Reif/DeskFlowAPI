namespace DeskFlowAPI.Models.Entidades
{
//     Categoria: o tipo do problema

// Serve pra organizar os chamados por assunto: Hardware, Software, Redes, Acessos. Assim o suporte consegue filtrar ("me mostra só os chamados de Redes") e saber pra qual time mandar cada um.
    public class Categoria
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public ICollection<Chamado> Chamados {get; set;} = new List<Chamado>();
    }
}