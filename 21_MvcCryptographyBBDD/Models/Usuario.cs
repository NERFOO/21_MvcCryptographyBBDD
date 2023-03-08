using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _21_MvcCryptographyBBDD.Models
{
    [Table("USERS")]
    public class Usuario
    {
        [Key]
        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }


        [Column("NOMBRE")]
        public string Nombre { get; set; }


        [Column("EMAIL")]
        public string Email { get; set; }


        [Column("SALT")]
        public string Salt { get; set; }


        [Column("IMAGEN")]
        public string Imagen { get; set; }

        //LOS TIPOS VARBINARY, CLOB, BLOB, SON CONVERTIDOS AUTOMATICAMENTE A BYTE[] POR EF
        [Column("PASS")]
        public byte[] Password { get; set; }
    }
}
