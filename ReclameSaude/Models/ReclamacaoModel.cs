namespace br.com.devset.ReclameSaude.Models
{
    public class ReclamacaoModel
    {
        public int ReclamacaoId { get; set; } // Chave primária

        public string Descricao { get; set; } = string.Empty; // Descrição da reclamação, obrigatório

        // Relacionamento com Hospital
        public int HospitalId { get; set; } // Chave estrangeira
        public HospitalModel? Hospital { get; set; } // Navegação para o hospital

        // Relacionamento com Usuario
        public int UsuarioId { get; set; } // Chave estrangeira
        public UsuarioModel? Usuario { get; set; } // Navegação para o usuário
    }
}
