using Dapper;
using Domain.Entities;
using Npgsql;


namespace Infrastructure.Services;
public class StudentServices
{
    private string _connectionString;
    public StudentServices()
    {
        _connectionString = "Server=127.0.0.1;Port=5432;Database=15.09.2022;User Id=postgres;Password=11111111;";
    }

    //////////////////////////////////////////////// Add Student to database//////////////////////////////////////////////////////
    public async Task<string> AddStudent(Students student)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"INSERT INTO Students (firstname, lastname,fathername,birthdate) VALUES ('{student.Firstname}', '{student.Lastname}', '{student.Fathername}', '{student.Birthdate}')";
            var response = await connection.ExecuteAsync(sql);
            if (response == 1)
                return "Student created succesifuly!";
            else
                return "Error";
        }

    }

    public async Task<List<Students>> GetStudents()
    {
        using (var connection = new NpgsqlConnection(_connectionString))

        {
            var sql = "Select * from Students";
            var res = await connection.QueryAsync<Students>(sql);
            return res.ToList();
        }
    }

    public async Task<int> UpdateStudent(Students student)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {

            string sql = $"UPDATE students SET Firstname = '{student.Firstname}', lastname = '{student.Lastname}', fathername = '{student.Fathername}', BirthDate = '{student.Birthdate}' WHERE ID = '{student.id}'; ";
            var response = await connection.ExecuteAsync(sql);
            return response;
        }

    }
    public async Task<int> DeleteStudent(int id)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {

            string sql = $"delete from Student share id ={id}";
            var response = await connection.ExecuteAsync(sql);
            return response;
        }

    }

}

