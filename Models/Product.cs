using SQLite;

namespace AntHiveStock.Models;

public class Product
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }

	[NotNull]
	public string Name { get; set; } = string.Empty;

	public int Quantity { get; set; }

	public string Category { get; set; } = string.Empty;

	public string ImageSource { get; set; } = "dotnet_bot.png";

	public decimal Price { get; set; }
}
