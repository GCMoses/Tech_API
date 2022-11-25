﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;


public abstract record CPUModifiedDTO
{
    [Required(ErrorMessage = "CPU name is a required field.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Base Clock is a required field.")]
    public string? BaseClock { get; set; }

    [Required(ErrorMessage = "Boost Clock is a required field.")]
    public string? BoostClock { get; set; }

    [Required(ErrorMessage = "Yes = true & No = False.")]
    public string? HyperThreading { get; set; }

    [DisplayName("Core & Threads")]
    [Required(ErrorMessage = "CPU Core & Threads is a required field.")]
    public string? CPUCore { get; set; }

    [DisplayName("Thermal Design Power")]
    [Required(ErrorMessage = "CPU TDP is a required field.")]
    public string? CpuTDP { get; set; }

    [Required(ErrorMessage = "Cache is a required field.")]
    public string? Cache { get; set; }

    [Required(ErrorMessage = "Socket Size is a required field.")]
    public string? Socket { get; set; }

    [Required(ErrorMessage = "Price in Rand is a required field.")]
    public string? Price { get; set; }

    [Range(1, 10)]
    public double Rating { get; set; }
}

