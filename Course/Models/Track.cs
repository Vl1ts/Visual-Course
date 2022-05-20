using System;
using System.Collections.Generic;

namespace Course
{
    public partial class Track
    {
        public Track()
        {
            DogRaces = new HashSet<DogRace>();
            Trainers = new HashSet<Trainer>();
            Traps = new HashSet<Trap>();
        }

        public string Name { get; set; } = null!;
        public long? TotalWinners { get; set; }

        public virtual ICollection<DogRace> DogRaces { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }
        public virtual ICollection<Trap> Traps { get; set; }
    }
}
