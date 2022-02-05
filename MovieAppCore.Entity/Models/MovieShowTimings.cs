using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieAppCore.Entity.Models
{
   public class MovieShowTimings
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieShowTimeId { get; set; }
        public Movie movie { get; set; }
        [ForeignKey("movie")]
        public int MovieId { get; set; }
        public DateTime ShowDateTime { get; set; }

    }
}
