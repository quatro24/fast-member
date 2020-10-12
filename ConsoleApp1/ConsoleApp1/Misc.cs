using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Misc
    {
        [DataColumn("hitid")]
        public int HitId { get; set; }

        [DataColumn("instid")]
        public string ApplicationId { get; set; }
    }
}
