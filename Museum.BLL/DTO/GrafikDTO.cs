﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.BLL.DTO
{
    public class GrafikDTO
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string ExpositionName { get; set; }
        public override string ToString()
        {
            return "ID "+Id.ToString()+"| Name "+ExpositionName+"| Start time "
                +StartTime.ToString()+"\t| End Time "+EndTime.ToString()+"\n";
        }
    }
}
