using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityFinal.Models
{
    public class Disease
    {
        public int DiseaseId { get; set; }
        public string Name { get; set; }
        public string Treatment { get; set; }
        public string Description { get; set; }
        public string Medicine { get; set; }
    }
}