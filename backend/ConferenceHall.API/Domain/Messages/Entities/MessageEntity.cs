using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConferenceHall.API.Domain.Conferences.Entities;
using ConferenceHall.API.Domain.Shared;
using ConferenceHall.API.Domain.Users.Entities;

namespace ConferenceHall.API.Domain.Messages.Entities;

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
    
    public UserEntity Creator { get; set; } = new UserEntity();
    
    public ConferenceEntity Conference { get; set; } = new ConferenceEntity();
}