using System;
using System.Collections.Generic;

#nullable disable

namespace CopyPasteDAL.Models
{
    public partial class Data
    {
        public int? Id { get; set; }
        public string Pass { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Url { get; set; }
    }
}
