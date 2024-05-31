using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InterviewExam.Models
{
    public class RecyclableItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("RecyclableType")]
        public int RecyclableTypeId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal Weight { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal ComputedRate { get; set; }

        [StringLength(150)]
        public string ItemDescription { get; set; }

        public virtual RecyclableType RecyclableType { get; set; }
    }
}
