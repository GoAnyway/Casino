using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public int Balance { get; set; }
    }
}