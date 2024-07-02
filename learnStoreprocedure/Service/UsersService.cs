namespace learnStoreprocedure;

public class UsersService
{
    public UsersService(){}

    private void ExecuteStoreProcedure(){

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