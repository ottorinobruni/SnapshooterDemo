using Newtonsoft.Json;

public class UserServiceClient
{
    public string CreateUser(Guid userId, string firstName, string lastName, string email, int age)
    {
        // Simulate creating a user
        var newUser = new User
        {
            UserId = userId,
            FirstName = firstName,
            LastName = lastName,
            Age = age,
            Email = email,
            RegistrationDate = DateTime.UtcNow 
        };

        // Serialize the newUser object to a JSON string
        return JsonConvert.SerializeObject(newUser);
    }
}