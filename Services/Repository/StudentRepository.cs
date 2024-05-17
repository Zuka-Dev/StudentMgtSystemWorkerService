using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IConfiguration _configuration;

        public StudentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<Student>> GetAllStudents()
        {
            
            using var sqlClient = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            string sqlString = @"SELECT * FROM Students";

            var students = await sqlClient.QueryAsync<Student>(sqlString);
            var studentsList = new List<Student>(students);
            return studentsList;

            
           
            
        }
    }
}
