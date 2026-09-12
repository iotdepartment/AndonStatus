using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AndonStatus.Models;

[Table("Estado")]
public partial class Estado
{
    [Key]
    public int Id { get; set; }

    [Column("Estado")]
    [StringLength(50)]
    [Unicode(false)]
    public string Estado1 { get; set; } = null!;

    [InverseProperty("Estado")]
    public virtual ICollection<AndonRegistro> AndonRegistros { get; set; } = new List<AndonRegistro>();
}
