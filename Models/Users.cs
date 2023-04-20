using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TOTVS_Challenge.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(60)")]
        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [DisplayName("AssignedTasks")]
        public string? AssignedTasks { get; set; }

    }
}
