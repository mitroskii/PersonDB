﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task1.Model
{
    public partial class Phone
    {
        public long ID { get; set; }
        [Column(TypeName = "nchar(10)")]
        public string Type { get; set; }
        [Column(TypeName = "nchar(10)")]
        public string Number { get; set; }
        public long? PersonID { get; set; }

        [ForeignKey("PersonId")]
        [InverseProperty("Phone")]
        public Person Person { get; set; }
    }
}
