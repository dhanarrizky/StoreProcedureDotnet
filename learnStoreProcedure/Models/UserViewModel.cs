namespace learnStoreProcedure.Models;

public class UserViewModel {
    public int Id { get; set; }
    public String FirstName { get; set; } = null!;
    public String? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public Boolean IsActive { get; set; }
}