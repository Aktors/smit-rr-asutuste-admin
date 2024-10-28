using System.ComponentModel.DataAnnotations;

namespace asutus.domain.Entities;

public class Classifier
{
    [Key]
    public int Id { get; set; }    
    public string Group { get; set; }
    public string Code { get; set; }
    public string Name {get; set;}
}