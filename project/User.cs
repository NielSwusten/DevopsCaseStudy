using System.ComponentModel.DataAnnotations;

namespace project
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int scores { get; set; } 

    }
}