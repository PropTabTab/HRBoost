
namespace HRBoost.Entity
{
    public class FileType : BaseEntity
    {
        
        public string Name { get; set; }
        public string Description { get; set; }

        public static implicit operator FileType(Document v)
        {
            throw new NotImplementedException();
        }
    }
}
