using FichaCadastroAPI.Enumerators;

namespace FichaCadastroAPI.DTO.Detalhe
{
    public class DetalheReadDTO
    {
        public int Id { get; set; }
        public string Feedback { get; set; }
        public NotasEnum Notas { get; set; }
    }
}
