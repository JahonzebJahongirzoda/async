using Dapper;
using Domain.Entities;
using Npgsql;


namespace Infrastructure.Services;
public class BookServices
{
    private string _connectionString;
    public BookServices()
    {
        _connectionString = "Server=127.0.0.1;Port=5432;Database=15.09.2022;User Id=postgres;Password=11111111;";
    }

    //////////////////////////////////////////////// Add book to database//////////////////////////////////////////////////////
    public async Task<string> AddBook(Books book)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"INSERT INTO Books (Title, Authorid) VALUES ('{book.Title}', '{book.Authorid}')";
            var response = await connection.ExecuteAsync(sql);
            if (response == 1)
                return "Book created succesifuly!";
            else
                return "Error";
        }

    }

    public async Task<List<Books>> GetBooks()
    {
        using (var connection = new NpgsqlConnection(_connectionString))

        {
            var sql = "Select * from Books";
            var res = await connection.QueryAsync<Books>(sql);
            return res.ToList();
        }
    }

    public async Task<int> UpdateBook(Books book)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {

            string sql = $"UPDATE Books SET Title = '{book.Title}', surname = '{book.Authorid}' WHERE ID = '{book.id}'; ";
            var response = await connection.ExecuteAsync(sql);
            return response;
        }

    }
    public async Task<int> DeleteBook(int id)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {

            string sql = $"delete from book share id ={id}";
            var response = await connection.ExecuteAsync(sql);
            return response;
        }

    }

}

