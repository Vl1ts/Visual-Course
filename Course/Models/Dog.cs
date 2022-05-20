using System;
using System.Collections.Generic;

namespace Course
{
    public partial class Dog
    {
        public Dog()
        {
            DogRaces = new HashSet<DogRace>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public long? Runs { get; set; }
        public long? Wins { get; set; }
        public double? StrikeRate { get; set; }
        public long? LongestWinningSequence { get; set; }
        public long? LongestLosingSequence { get; set; }
        public long? CurrentLosingSequence { get; set; }
        public string? LastRun { get; set; }

        public virtual ICollection<DogRace> DogRaces { get; set; }
    }
}
