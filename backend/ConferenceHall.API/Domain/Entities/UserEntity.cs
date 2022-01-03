using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceHall.API.Domain.Entities
{
	[Table("users")]
	public class UserEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		[Column("id")]
		public Guid Id { get; set; }

		[Required]
		[StringLength(50)]
		[Column("login")]
		public string Login { get; set; }

		[Required]
		[StringLength(100)]
		[EmailAddress]
		[Column("email")]
		public string Email { get; set; }
		
		[Required]
		[Column("salt")]
		public string Salt { get; set; }

		[Required]
		[Column("password")]
		public string Password { get; set; }

		public ICollection<ConferenceEntity> Conferences { get; set; } = new List<ConferenceEntity>();
	}
}
