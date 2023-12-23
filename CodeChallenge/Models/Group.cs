using System.Collections.Generic;

namespace CodeChallenge.Models
{
    public class Group
    {
        public string GroupName { get; set; }
        public List<Team> Teams { get; set; } = new List<Team>();
    }
}
