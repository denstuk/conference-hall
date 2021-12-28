using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceHall.API.Domain.Entities;

[Table("conferences")]
public class ConferenceEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(200)]
    [Column("title")]
    public string Title { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();
}