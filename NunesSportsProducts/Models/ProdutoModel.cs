using System.ComponentModel.DataAnnotations;

namespace NunesSportsProducts.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} tamanho do nome deve ser entre {2} e {1}")]
        public string Nome { get; set; } = string.Empty;

       
        [Required(ErrorMessage = "{0} required")]
        [Range(0.99, 500000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [Display(Name = "Preco")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public float Preco { get; set; }


        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} o tamanho da descrição curta deve ser entre {2} e {1}")]
        public string DescricaoCurta { get; set; } = string.Empty;

        
        [StringLength(200, MinimumLength = 10, ErrorMessage = "{0} o tamanho da descrição completa deve ser entre {2} e {1}")]
        public string DescricaoCompleta { get; set; } = string.Empty;
    }
}
