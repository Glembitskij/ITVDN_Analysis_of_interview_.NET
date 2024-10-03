// що таке Single Responsibility Principle, яким чином недотримання цього принципу може впливати на написання Unit test?

// Single Responsibility Principle (Принцип єдиної відповідальності)
// є одним з принципів SOLID, який рекомендує, щоб клас мав лише
// одну причину для зміни. Це означає, що клас повинен виконувати лише
// одну роботу або мати лише одну область відповідальності.
// Якщо клас відповідає за кілька аспектів, то зміни в одному аспекті
// можуть призвести до внесення змін у іншому, і це може збільшити
// слабкість коду та його важкість у розумінні, розвитку та підтримці.
using before = BeforeRefactoring;
using after = AfterRefactoring;

before.User user1 = new before.User()
{
    FirstName = "Alex",
    LastName = "Shevchenko",
    Email = "test@gmail.com",
    SubscriptionExpirationDate = new DateTime(2024, 12, 30),
    SubscriptionType = before.SubscriptionTypes.Premium
};

user1.AddUser();
Console.WriteLine(user1.HasUnlimitedContentAccess());

new string('-', 30);

after.User user2 = new after.User()
{
    FirstName = "Alex",
    LastName = "Shevchenko",
    Email = "test@gmail.com",
    SubscriptionExpirationDate = new DateTime(2024, 12, 30),
    SubscriptionType = after.SubscriptionTypes.Premium
};

after.DBUser.AddUser(user2);
Console.WriteLine(after.AccessManager.HasUnlimitedContentAccess(user2));

namespace BeforeRefactoring
{
    public class User
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public SubscriptionTypes SubscriptionType { get; set; }
        public DateTime SubscriptionExpirationDate { get; set; }

        public void AddUser()
        {
            const string path = "test.txt";

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine($"{FirstName}-{LastName}-{Email}-{SubscriptionType}-{SubscriptionExpirationDate}");
            }
        }

        public bool HasUnlimitedContentAccess()
        {
            return SubscriptionType == SubscriptionTypes.Premium
                && SubscriptionExpirationDate > DateTime.Now;
        }
    }

    public enum SubscriptionTypes
    {
        Basic,
        Standard,
        Premium
    }
}

namespace AfterRefactoring
{
    public class User
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public SubscriptionTypes SubscriptionType { get; set; }
        public DateTime SubscriptionExpirationDate { get; set; }
    }

    public class DBUser
    {
        public static void AddUser(User user)
        {
            const string path = "test.txt";

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine($"{user.FirstName}-{user.LastName}-{user.Email}-{user.SubscriptionType}-{user.SubscriptionExpirationDate}");
            }
        }
    }

    public class AccessManager
    {
        public static bool HasUnlimitedContentAccess(User user)
        {
            return user.SubscriptionType == SubscriptionTypes.Premium
                && user.SubscriptionExpirationDate > DateTime.Now;
        }

        public static bool GetBasicContent(User user)
        {
            return user.SubscriptionType == SubscriptionTypes.Premium
                && user.SubscriptionExpirationDate > DateTime.Now;
        }
    }

    public enum SubscriptionTypes
    {
        Basic,
        Standard,
        Premium
    }
}