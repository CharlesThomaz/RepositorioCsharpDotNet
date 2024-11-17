using System.Collections.ObjectModel;

namespace br.com.devset.reclame.Models
{
    public class HospitalModel
    {
        public int HospitalId { get; set; } // Chave primária
        public string Nome { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;


        Collection<ReclamacaoModel> reclamacaoModels { get; set; }

        }
}
