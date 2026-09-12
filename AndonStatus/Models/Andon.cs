using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AndonStatus.Models;

[Table("Andon")]
public partial class Andon
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("Andon")]
    public virtual ICollection<AndonRegistro> AndonRegistros { get; set; } = new List<AndonRegistro>();
}
