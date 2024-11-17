namespace ProjetoTesteModel.Models
{
    public class ProdutoModel
    {
        public ProdutoModel(int id, string nome, double preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }

        public int Id { get; set; }
        public string Nome { get; set; }  
        public double Preco { get; set; }
    }

}
