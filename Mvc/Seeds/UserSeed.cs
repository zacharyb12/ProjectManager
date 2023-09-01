using System.Text.Json;
using Dal;
using Dal.Models;

namespace Mvc.Seeds;

public static class UserSeed
{
    public static void SeedUsers(DataContext dataContext)
    {
        if (dataContext.Users.Any()) return; // seed only if table is empty

        string userData = File.ReadAllText("Seeds/Jsons/Users.json");
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        IEnumerable<User>? users = JsonSerializer.Deserialize<IEnumerable<User>>(userData, options);

        foreach (User user in users)
        {
            Console.WriteLine(user.Name);
            dataContext.Users.Add(user);
        }
        dataContext.SaveChanges();
    }
}