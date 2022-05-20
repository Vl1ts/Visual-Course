using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using System.Reactive;
using System.Collections.ObjectModel;
using Course.Models;

namespace Course.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ObservableCollection<DogRace> dograces;
        public ObservableCollection<DogRace> DogRaces
        {
            get
            {
                return dograces;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref dograces, value);
            }
        }

        ObservableCollection<Dog> dogs;
        public ObservableCollection<Dog> Dogs
        {
            get
            {
                return dogs;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref dogs, value);
            }
        }

        ObservableCollection<Track> tracks;
        public ObservableCollection<Track> Tracks
        {
            get
            {
                return tracks;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref tracks, value);
            }
        }

        ObservableCollection<Trainer> trainers;
        public ObservableCollection<Trainer> Trainers
        {
            get
            {
                return trainers;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref trainers, value);
            }
        }

        ObservableCollection<Trap> traps;
        public ObservableCollection<Trap> Traps
        {
            get
            {
                return traps;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref traps, value);
            }
        }

        ObservableCollection<TabElement> tabs;
        public ObservableCollection<TabElement> Tabs
        {
            get
            {
                return tabs;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref tabs, value);
            }
        }

        public MainWindowViewModel()
        {
            Dogs = new ObservableCollection<Dog>();
            DogRaces = new ObservableCollection<DogRace>();
            Tracks = new ObservableCollection<Track>();
            Trainers = new ObservableCollection<Trainer>();
            Traps = new ObservableCollection<Trap>();

            using (var database = new databaseContext())
            {
                foreach (var dog in database.Dogs)
                {
                    Dogs.Add(dog);
                }

                foreach (var race in database.DogRaces)
                {
                    DogRaces.Add(race);
                }

                foreach (var track in database.Tracks)
                {
                    Tracks.Add(track);
                }

                foreach (var trainer in database.Trainers)
                {
                    Trainers.Add(trainer);
                }
                
                foreach (var trap in database.Traps)
                {
                    Traps.Add(trap);
                }
            }
            
            Tabs = new ObservableCollection<TabElement>();
            Tabs.Add(new TabElement("Dog"));
            Tabs.Add(new TabElement("Dog Race"));
            Tabs.Add(new TabElement("Track"));
            Tabs.Add(new TabElement("Trainer"));
            Tabs.Add(new TabElement("Trap"));

            AddRow = ReactiveCommand.Create<string, Unit>((name) =>
            {
                switch (name)
                {
                    case "Dog":
                        Dog dog = new Dog();
                        dog.Id = Dogs.Count + 1;
                        Dogs.Add(dog);
                        break;
                    case "Dog Race":
                        DogRace race = new DogRace();
                        race.Id = DogRaces.Count + 1;
                        DogRaces.Add(race);
                        break;
                    case "Track":
                        Track track = new Track();
                        track.Name = "Undefined";
                        Tracks.Add(track);
                        break;
                    case "Trainer":
                        Trainer trainer = new Trainer();
                        trainer.Id = Trainers.Count + 1;
                        Trainers.Add(trainer);
                        break;
                    case "Trap":
                        Trap trap = new Trap();
                        trap.TrackName = "Undefined";
                        Traps.Add(trap);
                        break;
                    default:
                        break;
                }

                return Unit.Default;
            });

            RemoveLine = ReactiveCommand.Create<string, Unit>((name) =>
            {
                return Unit.Default;
            });
        }

        public ReactiveCommand<string, Unit> AddRow { get; }
        public ReactiveCommand<string, Unit> RemoveLine { get; }
    }
}
