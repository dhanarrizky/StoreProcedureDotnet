using System.Data;
using System.Data.SqlClient;
using learnStoreProcedure.Models;

namespace learnStoreProcedure.Services;

public class UsersServices
{
    private readonly IConfiguration _configuration;
    private readonly string _conn;
    public UsersServices(IConfiguration configuration){
        _configuration = configuration;
        _conn = _configuration.GetConnectionString("LearnSPDotnet");
    }

    public List<UserViewModel> GetAllDataUsers(){
        List<UserViewModel> users = new List<UserViewModel>();

        using (SqlConnection con = new SqlConnection(_conn)){
            con.Open();
            using (SqlCommand cmd = new SqlCommand("GetAllDataUsers",con)){
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader()){
                    while (reader.Read())
                    {
                        users.Add(
                            new UserViewModel {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                FirstName = reader.GetString(reader.GetOrdinal("firstname")),
                                LastName = reader.GetString(reader.GetOrdinal("lastname")),
                                BirthDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("birthdate"))),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("isactive"))
                            }
                        );
                    }
                }
            }
        }

        return users;
    }

    public UserViewModel GetUserById(int id){
        UserViewModel user = new UserViewModel();

        using(SqlConnection con = new SqlConnection(_conn)){
            con.Open();
            using (SqlCommand cmd = new SqlCommand("GetUserById", con)){
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id",id);

                using(SqlDataReader reader = cmd.ExecuteReader()){
                    if(reader.Read()){
                        user.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        user.FirstName = reader.GetString(reader.GetOrdinal("firstname"));
                        user.LastName = reader.GetString(reader.GetOrdinal("lastname"));
                        user.BirthDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("birthdate")));
                        user.IsActive = reader.GetBoolean(reader.GetOrdinal("isactive"));
                    }
                }
            }
        }
        return user;
    }

    public String InsertDataUser(UserViewModel user){
        using(SqlConnection con = new SqlConnection(_conn)){
            con.Open();
            using (SqlCommand cmd = new SqlCommand("AddNewUser", con)){
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName",user.FirstName);
                cmd.Parameters.AddWithValue("@LastName",user.LastName);
                cmd.Parameters.AddWithValue("@birthdate",user.BirthDate.ToDateTime(TimeOnly.MinValue));
                cmd.Parameters.AddWithValue("@IsActive",user.IsActive);
                cmd.ExecuteNonQuery();
            }
        }

        return "";
    }

    public String UpdateDataUser(UserViewModel user){
        Console.WriteLine("test code until this one or not : ",  user.FirstName);
        using(SqlConnection con = new SqlConnection(_conn)){
            con.Open();
            using (SqlCommand cmd = new SqlCommand("UpdateUserById", con)){
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id",user.Id);
                cmd.Parameters.AddWithValue("@FirstName",user.FirstName);
                cmd.Parameters.AddWithValue("@LastName",user.LastName);
                cmd.Parameters.AddWithValue("@birthdate",user.BirthDate.ToDateTime(TimeOnly.MinValue));
                cmd.Parameters.AddWithValue("@IsActive",user.IsActive);
                cmd.ExecuteNonQuery();
            }
        }

        return "";
    }

    public String DeleteUserById(int id){
        using (SqlConnection con = new SqlConnection(_conn)){
            con.Open();
            using (SqlCommand cmd = new SqlCommand("DeleteUserById",con)){
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        return "Success To Delete users with id : " + id;;
    }

}