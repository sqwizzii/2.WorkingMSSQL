using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2.WorkingMSSQL.Data.Entities
{
    [Table("tblUsers")]
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = string.Empty;
        [StringLength(100)]
        public string? Email { get; set; }
        [Required, StringLength(20)]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public DateOnly BirthDate { get; set; }
    }
}
