using System.ComponentModel.DataAnnotations;

namespace asutus.domain.Entities;

public class InformationSystem
{
    [Key]
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    
    public ICollection<SystemInstance> SystemInstances { get; set; }
}