using System;
using System.Collections.Generic;

namespace Course
{
    public partial class DogRace
    {
        public long Id { get; set; }
        public string Date { get; set; } = null!;
        public string? TrackName { get; set; }
        public long DogId { get; set; }
        public string? Grade { get; set; }
        public string? Distance { get; set; }
        public string? Sp { get; set; }
        public string? Finish { get; set; }
        public double? Sectional { get; set; }
        public double? Time { get; set; }
        public string? Going { get; set; }
        public double? CalcTime { get; set; }
        public string? ChesterRating { get; set; }
        public long? TrainerId { get; set; }

        public virtual Dog Dog { get; set; } = null!;
        public virtual Track? TrackNameNavigation { get; set; }
        public virtual Trainer? Trainer { get; set; }
    }
}
