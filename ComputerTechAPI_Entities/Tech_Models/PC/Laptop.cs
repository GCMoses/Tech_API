﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerTechAPI_Entities.Tech_Models.PC;

public class Laptop
{

    [Column("LaptopId")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Laptop name is a required field.")]
    [MaxLength(100, ErrorMessage = "Maximum length for the Laptop Name is 100 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Model name is a required field.")]
    public string? Model { get; set; }

    [Required(ErrorMessage = "Display Size is a required field.")]
    public string? DisplaySize { get; set; }

    [Required(ErrorMessage = "Display resolution is a required field.")]
    public string? DisplayResolution { get; set; }

    [Required(ErrorMessage = "Processor is a required field.")]
    public string? Processor { get; set; }

    [DisplayName("HDD/SSD")]
    [Required(ErrorMessage = "HardDisk is a required field.")]
    public string? HardDisk { get; set; }

    [Required(ErrorMessage = "RAM is a required field.")]
    public string? Ram { get; set; }

    [Required(ErrorMessage = "Operating System is a required field.")]
    public string? OS { get; set; }

    [Required(ErrorMessage = "Graphics is a required field.")]
    public string? Graphics { get; set; }

    [Required(ErrorMessage = "Weight is a required field.")]
    public string? Weight { get; set; }

    [Required(ErrorMessage = "Price in Rand is a required field.")]
    public string? Price { get; set; }

    [Required(ErrorMessage = "Laptop Description is a required field.")]
    public string? LaptopDescription { get; set; }

    [Required(ErrorMessage = "Laptop Rating is a required field.")]
    [Range(1, 10)]
    public double Rating { get; set; }

    [ForeignKey(nameof(Product))]
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}
