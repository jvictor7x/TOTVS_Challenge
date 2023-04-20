using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TOTVS_Challenge.Models
{
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }

        [Column(TypeName = "nvarchar(60)")]
        [DisplayName("Title")]
        [Required]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [DisplayName("Description")]
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ConclusionDate { get; set; }

        public string? status { get; set; }
        public int? responsibleUserId { get; set; }

    }
}
