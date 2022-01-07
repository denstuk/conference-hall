using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConferenceHall.Domain.Conferences.Entities;
using ConferenceHall.Domain.Shared;
using ConferenceHall.Domain.Users.Entities;

namespace ConferenceHall.Domain.Messages.Entities;

[Table("message")]
public class MessageEntity : BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
    
    [Required]
    [MinLength(1)]
    [Column("text")]
    public string Text { get; set; } = default!;
    
    [Required]
    [Column("creator_id")]
    public Guid CreatorId { get; set; }
    
    [Required]
    [Column("conference_id")]
    public Guid ConferenceId { get; set; }
    
    public UserEntity Creator { get; set; } = default!;
    
    public ConferenceEntity Conference { get; set; } = default!;
}