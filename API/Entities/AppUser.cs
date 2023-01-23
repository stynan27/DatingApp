namespace API.Entities
{
  public class AppUser
    {
        // Entity framework will recognize Id as db primary key by default.
        // If you would like to name otherwise, you can use the [Key] attribute.
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}