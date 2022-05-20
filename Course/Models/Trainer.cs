using System;
using System.Collections.Generic;

namespace Course
{
    public partial class Trainer
    {
        public Trainer()
        {
            DogRaces = new HashSet<DogRace>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? TrackName { get; set; }
        public long? Runners { get; set; }
        public long? NoFavs { get; set; }
        public double? StartingFavP { get; set; }
        public long? Winners { get; set; }
        public double? WinnersP { get; set; }
        public long? NoWinFavs { get; set; }
        public double? FavWinPercent { get; set; }
        public double? ProfitLossToStake { get; set; }
        public string? AverageSp { get; set; }

        public virtual Track? TrackNameNavigation { get; set; }
        public virtual ICollection<DogRace> DogRaces { get; set; }
    }
}
