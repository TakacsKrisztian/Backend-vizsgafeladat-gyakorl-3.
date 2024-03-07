namespace Takács_Krisztián_backend3.Models
{
    public record VersenyzoDto(int Id, string Nev, int Orszagid, string Nem);
    public record CreateVersenyzoDto(string Nev, int Orszagid, string Nem);
    public record ModifyVersenyzoDto(string Nev, int Orszagid, string Nem);
    public record RemoveVersenyzoDto(int Id);
}