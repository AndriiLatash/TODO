using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Threading.Tasks;
using TodoListWebApp.Models;

namespace TodoListWebApp.Repository
{
	public interface IListRepository
	{
		void Create(TODOlist list);
		void Delete(int id);
		void Update(int id, TODOlist list);
		List<TODOlist> GetList();
		List<Categories> GetCategories();
		TODOlist GetStatus(int id);
		void CreateCategory(Categories categories);
		TODOlist GetId(int TaskId);

	}

	public class ListRepository : IListRepository
	{
		string connectionString = null;
		public ListRepository(string conn)
		{
			connectionString = conn;
		}

		public void Create(TODOlist list)
		{

			using (IDbConnection db = new SqlConnection(connectionString))
			{
				var sqlQuery = "INSERT INTO Tasks (TaskName, Status, Deadline, CategoryId) VALUES(@TaskName, @Status, @Deadline, @CategoryId)";
				db.Execute(sqlQuery, list);
			}
		}

		public void CreateCategory(Categories categories)
		{

			using (IDbConnection db = new SqlConnection(connectionString))
			{
				var sqlQuery = "INSERT INTO Catogories (CategoryName) VALUES(@CategoryName)";
				db.Execute(sqlQuery, categories);
			}
		}

		public void Delete(int id)
		{
			using (IDbConnection db = new SqlConnection(connectionString))
			{
				var sqlQuery = "DELETE FROM Tasks WHERE TaskId = @id";
				db.Execute(sqlQuery, new { id });
			}
		}

		public List<TODOlist> GetList()
		{
			using (IDbConnection db = new SqlConnection(connectionString))
			{
				return db.Query<TODOlist>("SELECT t.*, c.CategoryName FROM Tasks t JOIN Catogories c ON t.CategoryId = c.Id " +
				"ORDER BY t.Deadline ASC").ToList();
			}
		}

		public void Update(int id, TODOlist list)
		{
			using (IDbConnection db = new SqlConnection(connectionString))
			{
				var sqlQuery = "UPDATE Tasks SET Status = @Status WHERE TaskId = @id";
				db.Execute(sqlQuery, new { list.Status, id });
			}
		}

		public TODOlist GetStatus(int id)
		{
			using (IDbConnection db = new SqlConnection(connectionString))
			{
				return db.Query<TODOlist>("SELECT Status FROM Tasks WHERE TaskId = @id", new { id }).FirstOrDefault();
			}
		}
		public List<Categories> GetCategories()
		{
			using (IDbConnection db = new SqlConnection(connectionString))
			{
				return db.Query<Categories>("SELECT * FROM Catogories").ToList();
			}
		}
		public TODOlist GetId(int TaskId)
		{
			using (IDbConnection db = new SqlConnection(connectionString))
			{
				var query = "SELECT * FROM Tasks WHERE TaskId = @TaskId";
				return db.QueryFirstOrDefault<TODOlist>(query, new { TaskId });
			}
		}

		
	}
}