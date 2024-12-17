using System.ComponentModel.DataAnnotations;

namespace ASPBackend.Entities;

public class UserEntity
{
	public int Id { get; set; }

	[StringLength(16)]
	public string Username { get; set; }
	
	public int Coins { get; set; }
	public int Gems { get; set; }
}