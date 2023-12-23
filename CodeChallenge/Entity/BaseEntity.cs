using System;

namespace CodeChallenge.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public string RecordUser{ get; set; }

        public DateTime RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
