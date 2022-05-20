using System;
using System.Collections.Generic;

namespace Course
{
    public partial class Trap
    {
        public string TrackName { get; set; } = null!;
        public long Number { get; set; }
        public long? Runs { get; set; }
        public long? Wins { get; set; }
        public string? WinPercent { get; set; }

        public virtual Track TrackNameNavigation { get; set; } = null!;
    }
}
