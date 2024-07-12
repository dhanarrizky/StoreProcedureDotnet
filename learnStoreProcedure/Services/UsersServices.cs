namespace learnStoreProcedure.Services;

public class UsersServices
{
    public UsersServices(){}

    public String GetAllDataUsers(){
        return "Get All Data Users";
    }

    public String GetUserById(int id){
        return "Get User By Id = " + id;
    }

    public String DeleteUserById(int id){
        return "Detele User By Id = " + id;
    }

}

/*
        GetAllDataUsers
        GetUserById
        AddNewUser
        UpdateUserById
        DeleteUserById
*/