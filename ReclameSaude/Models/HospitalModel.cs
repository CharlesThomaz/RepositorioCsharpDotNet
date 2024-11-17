namespace br.com.devset.ReclameSaude.Models
{
    public class HospitalModel
    {
        public int HospitalId { get; set; } // Chave primária

        public string Nome { get; set; } = string.Empty; // Nome do hospital, obrigatório

        public string Endereco { get; set; } = string.Empty; // Endereço, obrigatório

        // Navegação para reclamações relacionadas
        public ICollection<ReclamacaoModel>? Reclamacoes { get; set; }
    }
}
