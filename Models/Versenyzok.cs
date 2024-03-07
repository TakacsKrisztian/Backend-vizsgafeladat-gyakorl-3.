namespace Takács_Krisztián_backend3.Models;

public partial class Versenyzok
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public int Orszagid { get; set; }

    public string Nem { get; set; } = null!;

    public virtual Orszagok Orszag { get; set; } = null!;

    public virtual ICollection<Szamok> Szamoks { get; set; } = new List<Szamok>();
}