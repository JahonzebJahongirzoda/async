using Dapper;
using Domain.Entities;
using Npgsql;


namespace Infrastructure.Services;
public class AuthorServices
{
    private string _connectionString;
    public AuthorServices()
    {
        _connectionString = "Server=127.0.0.1;Port=5432;Database=15.09.2022;User Id=postgres;Password=11111111;";
    }

    //////////////////////////////////////////////// Add author to database//////////////////////////////////////////////////////
    public async Task<string> AddAuthor(Authors author)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"INSERT INTO Authors (name, surname) VALUES ('{author.Name}', '{author.Surname}')";
            var response = await connection.ExecuteAsync(sql);
            if (response == 1)
                return "Author created succesifuly!";
            else
                return "Error";
        }

    }

    public async Task<List<Authors>> GetAuthors()
    {
        using (var connection = new NpgsqlConnection(_connectionString))

        {
            var sql = "Select * from Authors";
            var res = await connection.QueryAsync<Authors>(sql);
            return res.ToList();
        }
    }

    public async Task<int> UpdateAuthor(Authors author)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {

            string sql = $"UPDATE Authors SET Name = '{author.Name}', surname = '{author.Surname}' WHERE id = '{author.id}'; ";
            var response = await connection.ExecuteAsync(sql);
            return response;
        }

    }
    public async Task<int> DeleteAuthor(int id)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {

            string sql = $"delete from author share id ={id}";
            var response = await connection.ExecuteAsync(sql);
            return response;
        }

    }

}

