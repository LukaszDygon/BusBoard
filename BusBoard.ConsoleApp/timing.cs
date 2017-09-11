using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    class Timing
    {
        //DateTime type;
        public DateTime CountdownServerAdjustment { get; set; }
        public DateTime Source { get; set; }
        public DateTime Insert { get; set; }
        public DateTime Read { get; set; }
        public DateTime Sent { get; set; }
        public DateTime Received { get; set; }

    }
}
