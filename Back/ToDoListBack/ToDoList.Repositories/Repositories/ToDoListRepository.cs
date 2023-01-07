using Dapper;
using Entities;
using Entities.Configs;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Repositories.Interfaces;

namespace ToDoList.Repositories.Repositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private string _conString = "Host=192.168.133.128;Port=5432;Database=Test1;Username=postgres;Password=123qwe45asd";
        private NpgsqlConnection _connection;
        private string _tableName = "ToDoTable";
        private string _databaseName = "ToDoAppDB";
        private DataBaseCreds _creds;
        public ToDoListRepository(DataBaseCreds creds)
        {
            _creds = creds;
            string conString = $"Host={_creds.Host};Port={_creds.Port};Username={_creds.UserName};Password={_creds.Password}";
            _connection = new NpgsqlConnection(conString);

            _connection.Open();
            CreateDataBase();
            _connection.Close();

            conString = $"Host={creds.Host};Port={creds.Port};Database={_databaseName};Username={creds.UserName};Password={creds.Password}";
            _connection = new NpgsqlConnection(conString);
            _connection.Open();
            CreateTable();
        }


        private void CreateDataBase()
        {
            try
            {
                string sql = @"CREATE DATABASE " + $"\"{_databaseName}\"" + "" +
                    @"WITH
                OWNER = postgres
                ENCODING = 'UTF8'
                LC_COLLATE = 'en_US.UTF-8'
                LC_CTYPE = 'en_US.UTF-8'
                TABLESPACE = pg_default
                CONNECTION LIMIT = -1
                IS_TEMPLATE = False;";
                _connection.Execute(sql);
            }
            catch (Exception ex)
            {
                /// тут должно быть логирование
            }

        }
        private void CreateTable()
        {
            _connection.Execute($"CREATE TABLE IF NOT EXISTS {_tableName} " +
                   $"(  " +
                   $"Id serial PRIMARY KEY , " +
                   $"Text text , " +
                   $"Description Text, " +
                   $"DateCreate timestamp " +
                   $")");
        }

        public async Task<long> AddToDoAsync(ToDo toDo)
        {
            string sql = $"INSERT INTO {_tableName} (Text,Description,DateCreate) VALUES (@Text,@Description,@DateCreate) RETURNING Id";
            toDo.DateCreate = DateTime.Now.ToUniversalTime();
            return (await _connection.QueryAsync<long>(sql, toDo)).FirstOrDefault();
        }

        public async Task<IEnumerable<ToDo>> GetToDoListAsync()
        {
            string sql = $"SELECT * FROM {_tableName}";
            var result = await _connection.QueryAsync<ToDo>(sql);
            return result.ToList();
        }

        public async Task RemoveToDo(long Id)
        {
            string sql = $"DELETE FROM {_tableName} where Id = @id";
            await _connection.QueryAsync(sql, new
            {
                id = Id
            });

        }

        public async Task Edit(ToDo toDo)
        {
            string sql = $"UPDATE {_tableName} SET Description = @Description, Text = @Text WHERE Id = @Id ";
            await _connection.ExecuteAsync(sql, toDo);
        }

        public async Task<ToDo> GetTaskById(long Id)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE Id = @id";
            var result = (await _connection.QueryAsync<ToDo>(sql, new {
                id = Id
            })).FirstOrDefault();

            return result;
        }
    }
}
