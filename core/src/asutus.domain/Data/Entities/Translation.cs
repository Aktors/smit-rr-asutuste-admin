using System.ComponentModel.DataAnnotations;

namespace asutus.domain.Entities;

public class Translation
{
    [Key]
    public int Id { get; set; }
    public int LanguageId { get; set; }
    public int AsutusId { get; set; }
    public string Text { get; set; }
    
    public Classifier Language { get; set; }
    public Asutus Asutus { get; set; }
}