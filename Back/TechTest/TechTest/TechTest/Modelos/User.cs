using System;
using System.Collections.Generic;

namespace TechTest.Modelos;

public partial class User
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Correo { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
