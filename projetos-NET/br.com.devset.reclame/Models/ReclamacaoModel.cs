namespace br.com.devset.reclame.Models
{
    public class ReclamacaoModel
    {
        public int ReclamacaoId { get; set; }

        public string Descricao { get; set; } = string.Empty;

        // Chave estrangeira e navegação para Hospital
        public int HospitalId { get; set; }
        public HospitalModel? Hospital { get; set; } // Não nullable se for obrigatório

        // Chave estrangeira e navegação para Usuario
        public int UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; } // Não nullable se for obrigatório
    }

}
