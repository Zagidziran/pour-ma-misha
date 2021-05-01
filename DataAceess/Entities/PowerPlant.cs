using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAceess.Entities
{
    public class PowerPlant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long CountryId { get; set; } = default!;

        public string Name { get; set; } = default!;

        public int ReactorCount { get; set; }

        public string ReactorType { get; set; } = default!;

        public int GrossCapacity { get; set; }

        public int NetCapacity { get; set; }

        [Range(1954, 2050)]
        public int CommissedAt { get; set; }

        [Range(1954, 2050)]
        public int DecommissedAt { get; set; }

        public int MonitoringPeriod { get; set; }

        public PlantStatus Satus { get; set; }
    }
}
