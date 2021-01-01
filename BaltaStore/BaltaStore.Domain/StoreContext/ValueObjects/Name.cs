namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Name
    {
        public Name(string firstName,string lastname)
        {
            FirstName = firstName;
            LastName = lastname;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
