namespace br.com.devset.ReclameSaude.Models
{
    public class UsuarioModel
    {
        public int UsuarioId { get; set; } // Chave primária

        public string Nome { get; set; } = string.Empty; // Nome do usuário, obrigatório

        public string Email { get; set; } = string.Empty; // Email, obrigatório

        public string WatsApp { get; set; } = string.Empty; // WhatsApp, obrigatório

        public DateTime? DataNascimento { get; set; } // Data de nascimento, opcional

        public string Senha { get; set; } = string.Empty; // Senha, obrigatório

        // Navegação para reclamações feitas pelo usuário
        public ICollection<ReclamacaoModel>? Reclamacoes { get; set; }
    }
}
