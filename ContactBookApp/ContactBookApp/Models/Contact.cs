using SQLite;

namespace ContactBookApp.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string PhoneNumber { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        public bool Blocked { get; set; }


    }
}
