using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarsWebAPI.Models;

[Table("MyCar")]
[Index("OwnerId", Name = "IX_MyCar_OwnerId")]
public partial class MyCar
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    public string Brand { get; set; } = null!;

    [StringLength(30)]
    public string Model { get; set; } = null!;

    public int Speed { get; set; }

    public int Weight { get; set; }

    public int Price { get; set; }

    public DateTime Year { get; set; }

    public int OwnerId { get; set; }
}
