using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceHall.Domain.Shared;

public class BaseEntity
{
    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }
    
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}