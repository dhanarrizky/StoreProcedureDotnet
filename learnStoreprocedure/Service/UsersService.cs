using System.Data;
using System.Data.SqlClient;
using learnStoreprocedure.Models;

namespace learnStoreprocedure;

public class UsersService
{
    private readonly String _conString;
    public UsersService(IConfiguration configuration){
        _conString = configuration.GetConnectionString("newdbforlearnspConnection");
    }

    public List<UserViewModel> GetAllUsers () {
        List<UserViewModel> users = new List<UserViewModel>();

        using (SqlConnection con = new SqlConnection(_conString)){
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
}
/**
dm name newdbforlearnsp


exec GetAllDataUsers
exec GetUserById @Id = 2006
exec AddNewUser @FirstName = 'hhhhh' , @LastName = 'test', @BiirthData = '11-8-2001', @IsActive = 0
exec UpdateUserById @Id = 3003, @FirstName = 'test' , @LastName = 'test', @BiirthData = '11-8-2001', @IsActive = 1
exec DeleteUserById @Id = 3003
*/