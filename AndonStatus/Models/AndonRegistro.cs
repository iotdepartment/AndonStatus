using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AndonStatus.Models;

[Table("AndonRegistro")]
public partial class AndonRegistro
{
    [Key]
    public int Id { get; set; }

    public int AndonId { get; set; }

    public int EstadoId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaHora { get; set; }

    [ForeignKey("AndonId")]
    [InverseProperty("AndonRegistros")]
    public virtual Andon Andon { get; set; } = null!;

    [ForeignKey("EstadoId")]
    [InverseProperty("AndonRegistros")]
    public virtual Estado Estado { get; set; } = null!;
}
