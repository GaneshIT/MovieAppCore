using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieAppCore.Entity.Models
{
   public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }

        [Required(ErrorMessage ="Movie name cannot be empty")]
        public string MovieName { get; set; }
        [Required]
        public string MovieDescription { get; set; }
        [Required]
        public string MovieType { get; set; }
        [Required]
        public string MovieLanguage { get; set; }
        [Required]
        public byte[] ImgPoster { get; set; }
    }
}
