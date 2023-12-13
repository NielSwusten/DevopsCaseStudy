using System.ComponentModel.DataAnnotations;

namespace project
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public double FastestTime { get; set; } // Add this property
    }

    public class highscore
    {
        [Key]
        public int Id { get; set; }
        public int score { get; set; }
        public string name { get; set; }

    }


    public class FastestTime
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Time { get; set; } // Assuming time is in milliseconds

    }
}
