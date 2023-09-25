using FichaCadastroAPI.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FichaCadastroAPI.Model
{
    [Table("Telefone")]
    public class TelephoneModel:RelacionalBase
    {
        [Column(TypeName = "VARCHAR"), StringLength(100)]
        public string Ddd { get; set; }
        [Column(TypeName = "VARCHAR"), StringLength(100)]
        public string Number { get; set; }
        public bool Ative { get; set; }
        [Required]
        public FichaModel Ficha { get; set; }
        public int FichaId { get; set; }
    }
}
