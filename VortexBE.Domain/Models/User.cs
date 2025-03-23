using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexBE.Domain.Models
{
    [Table("User")]
    public class User : Auditory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("UserId")]
        public int UserId { get; set; }

        [Column("Nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Column("Apellido")]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Column("Username")]
        [StringLength(50)]
        public string Username { get; set; }

        [Column("Email")]
        [StringLength(150)]
        public string Email { get; set; }

        [Column("Telefono")]
        [StringLength(30)]
        public string Telefono { get; set; }

        [Column("PasswordHash")]
        [StringLength(600)]
        public string PasswordHash { get; set; }

        public bool? Activo { get; set; }

    }
}
