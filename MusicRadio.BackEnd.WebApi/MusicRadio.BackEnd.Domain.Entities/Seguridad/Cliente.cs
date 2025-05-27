using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRadio.BackEnd.Domain.Entities.Seguridad
{
    public class Cliente
    {
        [Key]
        [Required]
        [StringLength(10)]
        public int IdCliente { get; set; }
        [Required]
        [StringLength(100)]
        public string CodId { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Correo { get; set; }
        [Required]
        [StringLength(500)]
        public string Direccion { get; set; }
        [Required]
        [StringLength(20)]
        public string Telefono { get; set; }
    }
}
