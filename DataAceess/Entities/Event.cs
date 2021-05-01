using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAceess.Entities
{
    public class Event
    {
        public long Id { get; set; }

        public DateTimeOffset Date { get; set; }

        public long PlantId { get; set; }

        public string Description { get; set; } = default!;

        public string Reason { get; set; } = default!;

        [Range(0, 7)]
        public int Rating { get; set; }

        public string Consequences { get; set; } = default!;
    }
}
