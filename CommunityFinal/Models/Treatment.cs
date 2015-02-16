using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunityFinal.Models
{
    public class Treatment
    {
        public int TreatmentId { get; set; }
        public string Id { get; set; }
        public string Observation { get; set; }

        [DisplayName("Observation Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public int DiseaseId { get; set; }
        public int MedicineId { get; set; }
        public int DoseId { get; set; }
        public int MealId { get; set; }
        public string Note { get; set; }
        public virtual DoctorEntry ADoctorEntry { get; set; }
        public virtual Disease ADisease { get; set; }
        public virtual Medicine AMedicine { get; set; }
        public virtual Dose ADose { get; set; }
        public virtual Meal AMeal { get; set; }
    }
}