public class TelephoneCreateDTO
{
    public string Ddd { get; set; }
    public string Number { get; set; }
    public bool ative { get; set; }

    public override string ToString() => $"({Ddd}) {Number}";
   
}
