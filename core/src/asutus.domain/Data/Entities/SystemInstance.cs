using System.ComponentModel.DataAnnotations;

namespace asutus.domain.Entities;

public class SystemInstance
{
    [Key]
    public int Id { get; set; }
    public int InformationSystemId { get; set; }
    public int InstanceTypeId { get; set; }

    public InformationSystem InformationSystem { get; set; }
    public Classifier InstanceType { get; set; }
}