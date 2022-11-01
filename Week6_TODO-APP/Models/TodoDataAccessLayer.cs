using Week6_TODO_APP;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Week6_TODO_APP.Utility;
using System.Data;

namespace Week6_TODO_APP.Models
{

    public class TodoDataAccessLayer
    {
        public readonly string connectionString = ConnectionString.CName;
        public IEnumerable<TodoModel> GetAllTodo()
        {
            List<TodoModel> lstTodo = new List<TodoModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllTodo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader  rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    TodoModel todoModel = new TodoModel();
                    todoModel.Id = Convert.ToInt32(rdr["Id"]);
                    todoModel.TaskName = rdr["TaskName"].ToString();
                    todoModel.Status = rdr["Status"].ToString();

                    lstTodo.Add(todoModel);
                }

                con.Close();
            }
            return lstTodo;
        }

        public void AddTodo (TodoModel todo)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddTodo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@Id", todo.Id);
                cmd.Parameters.AddWithValue("@TaskName", todo.TaskName);
                cmd.Parameters.AddWithValue("@Status", todo.Status);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            } 
        }

        public void UpdateTodo(TodoModel todo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateTodo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", todo.Id);
                cmd.Parameters.AddWithValue("@TaskName", todo.TaskName);
                cmd.Parameters.AddWithValue("@Status", todo.Status);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }          

        }

        public TodoModel GetTodoData(int? id)
        {
            TodoModel model = new TodoModel();
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM ToDo_Records WHERE Id = " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    model.Id = Convert.ToInt32(rdr["Id"]);
                    model.TaskName = rdr["TaskName"].ToString();
                    model.Status = rdr["Status"].ToString();
                }
            }
            return model;
        }

        public void DeleteTodo(int? id)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteTodo", con);
                //SqlCommand cmd = new SqlCommand("spGetAllTodo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }

}
