using System;

namespace Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }
        public string Nickname { get; set; }
    }
}