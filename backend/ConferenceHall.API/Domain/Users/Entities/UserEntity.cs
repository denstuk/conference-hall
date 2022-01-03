using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConferenceHall.API.Domain.Conferences.Entities;
using ConferenceHall.API.Domain.Users.Enums;

namespace ConferenceHall.API.Domain.Users.Entities
{
	[Table("users")]
	public class UserEntity
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

		public ICollection<ConferenceEntity> Conferences { get; set; } = new List<ConferenceEntity>();
	}
}
