using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2Mvc2.Models
{
    [Table("film_actor")]
    public partial class FilmActor
    {
        [Key]
        [Column("actor_id")]
        public int ActorId { get; set; }
        [Key]
        [Column("film_id")]
        public int FilmId { get; set; }
        [Column("last_update", TypeName = "datetime")]
        public DateTime LastUpdate { get; set; }

        [ForeignKey(nameof(ActorId))]
        [InverseProperty("FilmActor")]
        public virtual Actor Actor { get; set; }
        [ForeignKey(nameof(FilmId))]
        [InverseProperty("FilmActor")]
        public virtual Film Film { get; set; }
    }
}
