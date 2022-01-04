using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConferenceHall.API.Domain.Messages.Entities;
using ConferenceHall.API.Domain.Shared;
using ConferenceHall.API.Domain.Users.Entities;

namespace ConferenceHall.API.Domain.Conferences.Entities;

[Table("conferences")]
public class ConferenceEntity : BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Required]
    [StringLength(200)]
    [Column("title")]
    public string Title { get; set; } = default!;

    [Required]
    [Column("creator_id")] 
    public Guid CreatorId { get; set; } = default!;

    public UserEntity Creator { get; set; } = default!;
    public List<UserEntity> Users { get; set; } = new();
    public List<MessageEntity> Messages { get; set; } = new();
}