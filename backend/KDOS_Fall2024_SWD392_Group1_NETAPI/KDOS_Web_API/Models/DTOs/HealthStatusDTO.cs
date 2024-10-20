﻿using System;
using KDOS_Web_API.Models.Domains;
using System.ComponentModel.DataAnnotations;

namespace KDOS_Web_API.Models.DTOs
{
	public class HealthStatusDTO
	{
        [Key]
        public int HealthStatusId { get; set; }
        required public DateTime Date { get; set; }
        required public String Status { get; set; }
<<<<<<< Updated upstream
        required public float Temperature { get; set; }
        required public float OxygenLevel { get; set; }
        required public float PHLevel { get; set; }
        required public String Notes { get; set; }
  
=======
        required public String Description { get; set; }
        // Relationship
        public int OrderDetailsId { get; set; }
>>>>>>> Stashed changes
    }
}

