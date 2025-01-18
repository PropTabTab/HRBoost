namespace HRBoost.Entity
{
    public class FileType : BaseEntity
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
