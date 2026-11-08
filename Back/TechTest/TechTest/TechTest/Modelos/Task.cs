using System;
using System.Collections.Generic;

namespace TechTest.Modelos;

public partial class Task
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public int? UsuarioId { get; set; }

    public string? MetadataTarea { get; set; }

    public virtual User? Usuario { get; set; }
}
