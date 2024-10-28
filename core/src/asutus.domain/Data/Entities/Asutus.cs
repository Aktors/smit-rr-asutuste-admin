using System.ComponentModel.DataAnnotations;

namespace asutus.domain.Entities;

public class Asutus
{
    [Key]
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    
    public ICollection<Translation> Translations { get; set; }
}