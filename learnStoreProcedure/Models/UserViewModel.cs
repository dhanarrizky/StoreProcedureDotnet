namespace learnStoreProcedure.Models;

public class UserViewModel {
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public Boolean IsActive { get; set; }
}