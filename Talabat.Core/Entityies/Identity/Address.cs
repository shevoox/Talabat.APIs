namespace Talabat.Core.Entityies.Identity
{
    public class Address
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string AppUserId { get; set; }// Foreign Key :User
        public string Country { get; set; }
    }
}