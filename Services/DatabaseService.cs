using AntHiveStock.Models;
using SQLite;

namespace AntHiveStock.Services;

public class DatabaseService
{
	private const string DatabaseFilename = "anthivestock.db3";

	private static readonly SQLiteOpenFlags Flags =
		SQLiteOpenFlags.ReadWrite |
		SQLiteOpenFlags.Create |
		SQLiteOpenFlags.SharedCache;

	private SQLiteAsyncConnection? database;

	private async Task InitializeAsync()
	{
		if (database is not null)
		{
			return;
		}

		var databasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
		database = new SQLiteAsyncConnection(databasePath, Flags);

		await database.CreateTableAsync<Product>();
	}

	public async Task<List<Product>> GetProductsAsync()
	{
		await InitializeAsync();

		return await database!
			.Table<Product>()
			.OrderBy(product => product.Name)
			.ToListAsync();
	}

	public async Task<Product?> GetProductByIdAsync(int id)
	{
		await InitializeAsync();

		return await database!
			.Table<Product>()
			.FirstOrDefaultAsync(product => product.Id == id);
	}

	public async Task<int> SaveProductAsync(Product product)
	{
		await InitializeAsync();

		return product.Id == 0
			? await database!.InsertAsync(product)
			: await database!.UpdateAsync(product);
	}

	public async Task<int> DeleteProductAsync(Product product)
	{
		await InitializeAsync();

		return await database!.DeleteAsync(product);
	}
}
