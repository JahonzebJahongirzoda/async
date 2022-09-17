using Dapper;
using Domain.Entities;
using Npgsql;


namespace Infrastructure.Services;
public class CategoryServices
{
    private string _connectionString;
    public CategoryServices()
    {
        _connectionString = "Server=127.0.0.1;Port=5432;Database=15.09.2022;User Id=postgres;Password=11111111;";
    }

    //////////////////////////////////////////////// Add Category to database//////////////////////////////////////////////////////
    public async Task<string> AddCategory(Categories categories)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"INSERT INTO Categories(name) VALUES ('{categories.Name}')";
            var response = await connection.ExecuteAsync(sql);
            if (response == 1)
                return "Category created succesifuly!";
            else
                return "Error";
        }

    }

    public async Task<List<Categories>> GetCategory()
    {
        using (var connection = new NpgsqlConnection(_connectionString))

        {
            var sql = "Select * from Categories";
            var res = await connection.QueryAsync<Categories>(sql);
            return res.ToList();
        }
    }

    public async Task<int> UpdateCategory(Categories category)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {

            string sql = $"UPDATE Categories SET Name = '{category.Name}' WHERE ID = '{category.id}'; ";
            var response = await connection.ExecuteAsync(sql);
            return response;
        }

    }
    public async Task<int> DeleteCategory(int id)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {

            string sql = $"delete from category share id ={id}";
            var response = await connection.ExecuteAsync(sql);
            return response;
        }

    }

}

