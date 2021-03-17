using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MusicApp_API.Models
{
    public class Song
    {
        public Guid ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Composer { get; set; }

        [Required]
        public int Year { get; set; }

    }
}
