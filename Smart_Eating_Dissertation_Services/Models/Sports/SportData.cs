using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Eating_Dissertation_Services.Models.Sports
{
    public class SportData
    {
        [Key]
        public int Id { get; set; }
        public string sportName { get; set; }
        public string sportKcal { get; set; }
    }
}
