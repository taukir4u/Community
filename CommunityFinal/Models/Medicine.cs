using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityFinal.Models
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public double Power { get; set; }
        public int UnitId { get; set; }
        public virtual Unit AUnit { get; set; }
    }
}