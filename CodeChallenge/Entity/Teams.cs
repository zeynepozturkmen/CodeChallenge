namespace CodeChallenge.Entity
{
    public class Teams : BaseEntity
    {
        public string Name { get; set; }
        public int GroupsId { get; set; }
        public Groups Groups { get; set; }
    }
}
