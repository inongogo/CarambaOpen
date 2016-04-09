using System;
using System.Collections.Generic;
using System.Linq;
using CarambaOpen.Models;
using Microsoft.Extensions.DependencyInjection;
using CarambaOpen.Extensions;

namespace CarambaOpen.DbContexts
{
    public static class AppDbContextDataSeeder
    {
        public static void SeedDatabase(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<AppDbContext>();

            if (!context.Users.Any())
            {
                var users = new List<User>
                {
                    new User {Name = "Zider", Password = "clubodegolfo".Sha256()},
                    new User {Name = "(S)andy", Password = "blöjan".Sha256()},
                    new User {Name = "Björk...förlåt, Eken", Password = "enshottilltack".Sha256()},
                    new User {Name = "Heil, Puttern!", Password = "dontmentionthewar".Sha256()},
                    new User {Name = "Wheee i Russia are ya fraaa, sääär?", Password = "mygelhcp".Sha256()},
                    new User {Name = "I AM THE LIQUOR!", Password = "elcapitanloco".Sha256()},
                    new User {Name = "Nu ska vi leka ping-pong på jobbet också", Password = "bajen".Sha256()}
                };

                context.Users.AddRange(users);
            }
            if (!context.Questions.Any())
            {
                var qs = new List<Question>
                {
                    new Question
                    {
                        Order = 1,
                        Quest = "Vad är viktigast med resan för dig?",
                        Alt1 = "Nära till stad",
                        Alt2 = "Nära till många golfbanor",
                        Alt3 = "Bra boende som man kan festa i",
                        Alt4 = "Billigt"
                    },
                    new Question
                    {
                        Order = 2,
                        Quest = "Hur riskbenägen är du?",
                        Alt1 = "Fuck it, jag vågar inte gå ur sängen",
                        Alt2 =
                            "Jag undrar om isen håller...bäst att ta det försiktigt med broddar, ispicka, livliva, flytväst, dykarutrustning, tryckkammare och egen ambulans",
                        Alt3 = "Äh, jag skjuter lite från höften",
                        Alt4 = "Jag åker till Arlanda och tar första bästa kärra så får vi se vad som händer"

                    },
                    new Question
                    {
                        Order = 3,
                        Quest = "Vad är viktigast med golfen?",
                        Alt1 = "Gå runt och snacka lite skit med grabbarna",
                        Alt2 = "Bra bana är a och o",
                        Alt3 = "Kul att testa något nytt",
                        Alt4 = "Ska vara bra väder"
                    },
                    new Question
                    {
                        Order = 4,
                        Quest = "Vad är du beredd att lägga mest pengar på?",
                        Alt1 = "Bra kvalitet på golfbanorna",
                        Alt2 = "Ett sjyst hotell/lägenhet",
                        Alt3 = "Mat, dryck och leverne",
                        Alt4 = "Land med bra solgaranti"
                    },
                    new Question
                    {
                        Order = 5,
                        Quest = "Vad är viktigast med resmålet?",
                        Alt1 = "Billigt",
                        Alt2 = "Nytt land",
                        Alt3 = "Garanterat bra golfbanor",
                        Alt4 = "Nära till festställen"
                    },
                    new Question
                    {
                        Order = 6,
                        Quest = "Vad av följande är viktigast?",
                        Alt1 = "Om det skiter sig med en golfbana så är vi ganska säkra på att det löser sig ändå",
                        Alt2 = "G-bitch måste funka",
                        Alt3 = "Det bara måste finnas lite brüdar och lap-dances",
                        Alt4 = "Vi måste kunna festa på hotellet/lägenheten utan att bli utslängda första natten"
                    },
                    new Question
                    {
                        Order = 7,
                        Quest = "Hur skulle du vilja att fördelningen av pengar såg ut?",
                        Alt1 = "G = 20 %, F = 10 %, R = 30 %, B = 40 %",
                        Alt2 = "G = 40 %, F = 40 %, R = 10 %, B = 10 %",
                        Alt3 = "G = 20 %, F = 10 %, R = 50 %, B = 20 %",
                        Alt4 = "G = 25 %, F = 15 %, R = 20 %, B = 40 %"
                    },
                };

                context.Questions.AddRange(qs);
            }
            if (!context.Destinations.Any())
            {
                var destinations = new List<Destination>
                {
                    new Destination
                    {
                        DestinationCountry = "Sverige",
                        DestinationCity = "Öland",
                        CarRentalCost = 0,
                        FoodDrinkCost = 3000,
                        HotellName = "Stuga",
                        HotellUrl = "http://www.stugknuten.com/resultatoland.asp",
                        LivingCost = 6000 / 7,
                        LivingType = "Stuga",
                        TravelType = "Bil",
                        TravelCost = 6000 / 7,
                        GolfClub1Name = "Saxnäs GK",
                        GolfClub1Url = "http://www.saxnasgolf.se/",
                        GolfClub2Name = "Ekerum GK",
                        GolfClub2Url = "http://www.ekerum.com/golf/",
                        GolfClub3Name = "Grönhögen GK",
                        GolfClub3Url = "http://www.gronhogen.se/",
                        GolfCost = 600,
                        Pros = "Billigt, nära, slipper hyrbil, bra fest på lördagar i Borgholm och fredagar i Kalmar, hyra stuga = kan vara högljuda.",
                        Cons = "Riskfyllt med väder, tråkigt att inte åka utomlands, kan vara dåliga banor, flexibilitet"
                    },
                    new Destination
                    {
                        DestinationCountry = "Tjekien",
                        DestinationCity = "Prag",
                        CarRentalCost = 4500 / 7,
                        FoodDrinkCost = 3000,
                        HotellName = "Residence Leon D Oro",
                        HotellUrl = "http://sv.hotels.com/hotel/details.html?WOE=1&q-localised-check-out=2.5.2016&WOD=3&q-room-0-children=0&pa=3&tab=description&q-room-1-children=0&q-localised-check-in=27.4.2016&hotel-id=263868&q-room-0-adults=3&q-room-1-adults=2&q-room-2-adults=2&YGF=14&MGT=5&ZSX=0&SYE=3&q-room-2-children=0",
                        LivingCost = 17000 / 7,
                        LivingType = "Hotell",
                        TravelType = "Flyg (Norwegian)",
                        TravelCost = 9500 / 7,
                        GolfClub1Name = "Prague City Golf",
                        GolfClub1Url = "http://www.golfjournalen.se/clubs/golfclub/prague_city_gc/ (http://www.praguecitygolf.cz)",
                        GolfClub2Name = "Benesov (flera banor runt omkring...ca 45 min från Prag med bil)",
                        GolfClub2Url = "http://www.golf-konopiste.cz/index.php?textID=62&idmenu=6",
                        GolfClub3Name = "",
                        GolfClub3Url = "",
                        GolfCost = 700,
                        Pros = "Cool stad med bra fest, bra golfresor, billig sprit och mat, kan bo på flera ställen",
                        Cons = "Lite risk med väder, status på banor (ska dock vara bra), status på boende?, medelrisk"
                    },
                    new Destination
                    {
                        DestinationCountry = "Spanien",
                        DestinationCity = "Alicant",
                        CarRentalCost = 4500 / 7,
                        FoodDrinkCost = 3000,
                        HotellName = "Casa de Eke",
                        HotellUrl = "http://www.fuckmeharderplease.inout",
                        LivingCost = 14000 / 7,
                        LivingType = "Lägenhet",
                        TravelType = "Flyg (Norwegian)",
                        TravelCost = 20000 / 7,
                        GolfClub1Name = "Ni vet vilka",
                        GolfClub1Url = "www.FörAttDettaAlternativSkaVaraOkMåsteViHoraSomFanFörStoffe.com",
                        GolfClub2Name = "",
                        GolfClub2Url = "",
                        GolfClub3Name = "",
                        GolfClub3Url = "",
                        GolfCost = 850,
                        Pros = "Bra uteliv, billig, bra boende, bra uteliv, bra väder, ja...ni vet...",
                        Cons = "Ni har varit där många gånger, grannarna gillar inte vår ljudnivå kan jag tänka mig, Stoffe känner nog ett ansvar, vi måste smöra som fan för honom, har spelat klubbarna tidigare"
                    },
                    new Destination
                    {
                        DestinationCountry = "Irland",
                        DestinationCity = "Olika valmöjligheter",
                        CarRentalCost = 4500 / 7,
                        FoodDrinkCost = 5000,
                        HotellName = "Olika resorts",
                        HotellUrl = "http://www.golfjournalen.se/index.php/articles/golf/sol_vind_och_vatten/",
                        LivingCost = 30000 / 7,
                        LivingType = "Resort",
                        TravelType = "Flyg (Norwegian)",
                        TravelCost = 16000 / 7,
                        GolfClub1Name = "Blarney Resort",
                        GolfClub1Url = "http://www.blarneyresort.com/",
                        GolfClub2Name = "Lee Valley Golf & Country Club",
                        GolfClub2Url = "http://www.leevalleygcc.ie/",
                        GolfClub3Name = "",
                        GolfClub3Url = "",
                        GolfCost = 1000,
                        Pros = "Bra banor, golf i centrum, bra öl, bra party (i Dublin), trevligt folk",
                        Cons = "Kan bli dyrt med levnadskostnader, kan bli isolerade om vi kör resort, vädret är osäkert"
                    }

                };

                context.Destinations.AddRange(destinations);
            }

            context.SaveChanges();
        }
    }
}

