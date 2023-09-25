using FichaCadastroAPI.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FichaCadastroAPI.Model
{
    [Table("Telefone")]
    public class TelephoneModel:RelacionalBase
    {
        [Column(TypeName = "VARCHAR"), StringLength(100)]
        public int Ddd { get; set; }
        [Column(TypeName = "VARCHAR"), StringLength(100)]
        public int Number { get; set; }

        public bool ative { get; set; }
    }
}
