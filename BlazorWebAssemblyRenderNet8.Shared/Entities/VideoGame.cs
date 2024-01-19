using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebAssemblyRenderNet8.Shared.Entities
{
    [Table(name:"VIDEOGAME")]
    public class VideoGame
    {
        [Column(name:"ID")]
        public int Id { get; set; }

        [Column(name: "TITLE")]
        public string? Title { get; set; }

        [Column(name: "PUBLISHER")]
        public string? Publisher { get; set; }

        [Column(name: "RELEASEYEAR")]
        public int? ReleaseYear { get; set; }
    }
}
