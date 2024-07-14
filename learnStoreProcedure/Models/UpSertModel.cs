namespace learnStoreProcedure.Models;

public class UpSertModel {

    // for make page to know about where this page current position
    // Insert Form or Update Form
    public String CurrentPosition { get; set; } = "Insert";
    public UserViewModel? User { get; set; }
}