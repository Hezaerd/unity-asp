using ASPBackend.Data;
using ASPBackend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ASPBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(AppDbContext context) : ControllerBase
{
	[HttpGet]
	public IActionResult GetUsers()
	{
		return Ok(context.Users.ToList());
	}
	
	[HttpGet("{id:int}")]
	public IActionResult GetUser(int id)
	{
		UserEntity? user = context.Users.Find(id);

		if (user == null)
			return NotFound();

		return Ok(user);
	}
	
	[HttpPost("{username:required}")]
	public IActionResult CreateUser(string username)
	{
		UserEntity user = new UserEntity { Username = username };
		context.Users.Add(user);
		context.SaveChanges();
		
		return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
	}
	
	[HttpPost("{id:int}/{coins:int}")]
	public IActionResult SetCoins(int id, int coins)
	{
		UserEntity? user = context.Users.Find(id);

		if (user == null)
			return NotFound();

		if (coins < 0)
			return BadRequest("Coins cannot be negative");
		
		user.Coins = coins;
		if (user.Coins < 0)
			user.Coins = 0;
		
		context.SaveChanges();
		
		return Ok(user);
	}

	[HttpPatch("{id:int}/{coins:int}")]
	public IActionResult AddCoins(int id, int coins)
	{
		UserEntity? user = context.Users.Find(id);

		if (user == null)
			return NotFound();

		user.Coins += coins;
		if (user.Coins < 0)
			user.Coins = 0;
		
		context.SaveChanges();

		return Ok(user);
	}

	[HttpPost("{id:int}/{gems:int}")]
	public IActionResult SetGems(int id, int gems)
	{
		UserEntity? user = context.Users.Find(id);

		if (user == null)
			return NotFound();

		user.Gems = gems;
		if (user.Gems < 0)
			user.Gems = 0;

		context.SaveChanges();

		return Ok(user);
	}

	[HttpPatch("{id:int}/{gems:int}")]
	public IActionResult AddGems(int id, int gems)
	{
		UserEntity? user = context.Users.Find(id);

		if (user == null)
			return NotFound();

		user.Gems += gems;
		if (user.Gems < 0)
			user.Gems = 0;

		context.SaveChanges();

		return Ok(user);
	}
}