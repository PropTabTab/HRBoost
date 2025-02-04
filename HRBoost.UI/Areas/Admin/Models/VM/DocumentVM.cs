namespace HRBoost.UI.Areas.Admin.Models.VM
{
    public class DocumentVM
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string FileName { get; set; }

        public DateTime UploadDate { get; set; }
    }
}
