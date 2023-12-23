using System.Collections.Generic;

namespace CodeChallenge.Entity
{
    public class Groups : BaseEntity
    {
        public string GroupName { get; set; }
        public List<Teams> Teams { get; set; }
    }
}
