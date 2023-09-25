namespace FichaCadastroAPI.DTO.Ficha
{
    public class FichaTelephoneReadDTO:FichaReadDTO
    {
        public List<TelephoneReadDTO>? ListTelephones { get; set; }
    }
}
