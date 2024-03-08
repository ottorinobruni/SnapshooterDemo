using Newtonsoft.Json;
using Snapshooter.Xunit;

public class UserServiceClientTests
{
    [Fact]
    public void CreateUser_ShouldReturnValidUserJson()
    {
        // Arrange
        var serviceClient = new UserServiceClient();
        var userId = Guid.Parse("1292F21C-8501-4771-A070-C79C7C7EF451");
        var firstName = "Otto";
        var lastName = "Bruni";
        var age = 40;
        var email = "ottorino.bruni@gmail.com";

        // Act
        var resultJson = serviceClient.CreateUser(userId, firstName, lastName, email, age);

        // Assert
        //Snapshot.Match(resultJson);
        Snapshot.Match(resultJson, matchOptions => matchOptions.IgnoreField("RegistrationDate"));
    }

    [Fact]
    public void CreateUserWithoutSnapshot_ShouldReturnValidUserJson()
    {
        // Arrange
        var serviceClient = new UserServiceClient();
        var userId = Guid.Parse("1292F21C-8501-4771-A070-C79C7C7EF451");
        var firstName = "Otto";
        var lastName = "Bruni";
        var age = 40;
        var email = "ottorino.bruni@gmail.com";

        // Act
        var resultJson = serviceClient.CreateUser(userId, firstName, lastName, email, age);
        var deserializedUser = JsonConvert.DeserializeObject<User>(resultJson);

        // Assert
        Assert.NotNull(deserializedUser);
        Assert.Equal(userId, deserializedUser.UserId);
        Assert.Equal(firstName, deserializedUser.FirstName);
        Assert.Equal(lastName, deserializedUser.LastName);
        Assert.Equal(email, deserializedUser.Email);
        Assert.Equal(age, deserializedUser.Age);
    }
}