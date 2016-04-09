using System.Security.AccessControl;

namespace CarambaOpen.Models
{
    public class Destination
    {
        public int Id { get; set; }

        public string DestinationCountry { get; set; }
        public string DestinationCity { get; set; }

        public string HotellName { get; set; }
        public string HotellUrl { get; set; }

        public string TravelType { get; set; } // Flyg, bil, etc
        public string LivingType { get; set; } // Hotell, lägenhet, Stoffe, etc

        public string GolfClub1Name { get; set; }
        public string GolfClub1Url { get; set; }
        public string GolfClub2Name { get; set; }
        public string GolfClub2Url { get; set; }
        public string GolfClub3Name { get; set; }
        public string GolfClub3Url { get; set; }

        public int TravelCost { get; set; }
        public int LivingCost { get; set; }
        public int CarRentalCost { get; set; }
        public int FoodDrinkCost { get; set; }
        public int GolfCost { get; set; }

        public string Pros { get; set; }
        public string Cons { get; set; }
    }
}
