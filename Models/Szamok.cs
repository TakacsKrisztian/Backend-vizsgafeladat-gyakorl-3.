namespace Takács_Krisztián_backend3.Models;

public partial class Szamok
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public int Versenyzoid { get; set; }

    public virtual Versenyzok Versenyzo { get; set; } = null!;
}