﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Patient
    {
        public int id { get; set; }
        [Display(Name = "NAME")]
        public string name { get; set; }
        public float temp { get; set; }
        public string allergies { get; set; }
    }
    public class HospitalContext : DbContext 
    { 
        public DbSet<Patient> patient { get; set; }
        public DbSet<Doctor> doctor { get; set; }
        public DbSet<Appointment> apt { get; set; }
    } 
}