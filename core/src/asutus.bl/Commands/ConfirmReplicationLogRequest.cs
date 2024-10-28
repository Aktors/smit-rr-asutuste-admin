using MediatR;

namespace asutus.bl.Commands;

public class ConfirmReplicationLogRequest: IRequest<Unit>
{
    public ConfirmReplicationLogRequest(Guid referenceId, String conetnt)
    {
        ReferenceId = referenceId;
        Conetnt = conetnt;
    }
    
    public Guid ReferenceId { get; set; }
    public string Conetnt { get; set; }
}