namespace FichaCadastroAPI.DTO.Ficha
{
    public class FichaTelephoneReadDTO:TelephoneReadDTO
    {
        public List<TelephoneReadDTO>? ListTelephones { get; set; }
    }
}
