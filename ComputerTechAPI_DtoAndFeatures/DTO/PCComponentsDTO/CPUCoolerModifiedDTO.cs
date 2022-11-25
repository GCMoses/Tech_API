﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;


public abstract record CPUCoolerModifiedDTO
{
    [Required(ErrorMessage = "Cooler name is a required field.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Built In Fan is a required field.")]
    public string? BuiltInFan { get; set; }

    [Required(ErrorMessage = "Radiator is a required field.")]
    public string? Radiator { get; set; }

    [Required(ErrorMessage = "Fan Maximum Noise Level is a required field.")]
    public string? MaxFanNoiseLevel { get; set; }

    [DisplayName("Pulse Width Modulation")]
    [Required(ErrorMessage = "PWM Support is a required field.")]
    public string? PWMSupport { get; set; }

    [Required(ErrorMessage = "Maximum Airflow is a required field.")]
    public string? MaxAirflow { get; set; }

    [Required(ErrorMessage = "The value is a required field.")]
    public int NumberOfFans { get; set; }

    [Required(ErrorMessage = "Socket Support is a required field.")]
    public string? SocketSupport { get; set; }

    [Required(ErrorMessage = "Price in Rand is a required field.")]
    public string? Price { get; set; }

    [Range(1, 10)]
    public double Rating { get; set; }
}