using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAceess.Entities
{
    public class Country
    {
        public long Id { get; set; }

        public string Name { get; set; } = default!;

        [MaxLength(2)]
        public string Code { get; set; } = default!;

        public long ContinentId { get; set; } = default!;
    }
}
