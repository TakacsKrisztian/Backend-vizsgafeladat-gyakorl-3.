namespace Takács_Krisztián_backend3.Models;

public partial class Orszagok
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public string Nobid { get; set; } = null!;

    public virtual ICollection<Versenyzok> Versenyzoks { get; set; } = new List<Versenyzok>();
}