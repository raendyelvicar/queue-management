namespace Shared.Models;

public class Queue
{
    public int Id { get; set; }
    public string ServiceCode { get; set; }
    public string QueueNumber { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CalledAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public bool IsCalled { get; set; }
    public bool IsSkipped { get; set; }
}
