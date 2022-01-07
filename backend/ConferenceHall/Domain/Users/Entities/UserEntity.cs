using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConferenceHall.Domain.Conferences.Entities;
using ConferenceHall.Domain.Messages.Entities;
using ConferenceHall.Domain.Shared;
using ConferenceHall.Domain.Users.Enums;

namespace ConferenceHall.Domain.Users.Entities
{
	[Table("users")]
	public class UserEntity : BaseEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		[Column("id")]
		public Guid Id { get; set; }

		[Required] 
		[Column("role")]
		public UserRole Role { get; set; } = UserRole.Simple;

		[Required]
		[StringLength(50)]
		[Column("login")]
		public string Login { get; set; } = default!;

		[Required]
		[StringLength(100)]
		[EmailAddress]
		[Column("email")]
		public string Email { get; set; } = default!;

		[Required] 
		[Column("salt")] 
		public string Salt { get; set; } = default!;

		[Required] 
		[Column("password")] 
		public string Password { get; set; } = default!;
		
		[Column("blocked_until")]
		public DateTime? BlockedUntil { get; set; }

		public List<ConferenceEntity> Conferences { get; set; } = new();
		public List<ConferenceEntity> CreatedConferences { get; set; } = new();
		public List<MessageEntity> Messages = new();
	}
}
