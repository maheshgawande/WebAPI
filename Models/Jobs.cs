using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Jobs
    {
        [Required]
        public int Id { get; set; }
        [Display(Name ="CODE")]
        public string Code { get; set; } = String.Empty;
        public string Title { get; set; } = String.Empty;
        public string Desc { get; set; } = String.Empty;

        //public List<string> Location { get; set; }
        //public List<string> Department { get; set; }

        public int LocId { get; set; }
        public int DeptId { get; set; }
        public string PostedDate { get; set; }
        public string ClosingDate { get; set; }
    }
}
