using System.ComponentModel.DataAnnotations;

namespace NunesSportsProducts.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "{0} é necessário para o cadastro")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} tamanho do nome deve ser entre {2} e {1}")]
        public string Nome { get; set; } = string.Empty;

       
        [Required(ErrorMessage = "{0} é necessário para o cadastro")]
        [Range(0.99, 500000.00, ErrorMessage = "O preço deve ser entre R$ {1} e R${2}")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public float Preco { get; set; }


        [Required(ErrorMessage = "Descrição curta é necessário para o cadastro")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} o tamanho da descrição curta deve ser entre {2} e {1}")]
        public string DescricaoCurta { get; set; } = string.Empty;

        [Required(ErrorMessage = "Descrição completa é necessário para o cadastro")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "{0} o tamanho da descrição completa deve ser entre {2} e {1}")]
        public string DescricaoCompleta { get; set; } = string.Empty;
    }
}
