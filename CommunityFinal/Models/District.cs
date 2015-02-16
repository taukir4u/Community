using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunityFinal.Models
{
    public class District
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public int Population { set; get; }
        public virtual ICollection<CreateCenter> Centers { set; get; }

    }
}