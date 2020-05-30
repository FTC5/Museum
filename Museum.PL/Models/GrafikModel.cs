﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.PL.Models
{
    public class GrafikModel
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public virtual ExpositionModel Exposition { get; set; }
        public override string ToString()
        {
            return "ID "+Id.ToString()+"| Name "+ Exposition.ExpositionName + "| Start time "
                +StartTime.ToString()+"\t| End Time "+EndTime.ToString()+"\n";
        }
    }
}
