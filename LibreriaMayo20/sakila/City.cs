namespace LibreriaMayo20.sakila
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("city")]
    public partial class City
    {
        [Key]
        public int city_id { get; set; }

        [Column("city")]
        [Required]
        [StringLength(50)]
        public string city1 { get; set; }

        public short country_id { get; set; }

        public DateTime last_update { get; set; }
    }
}
