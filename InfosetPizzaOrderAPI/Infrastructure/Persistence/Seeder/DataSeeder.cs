using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DataContext;

namespace Persistence.Seeder
{
    public static class DataSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            DbContextOptions<InfosetDbContext> options = serviceProvider.GetRequiredService<DbContextOptions<InfosetDbContext>>();
            InfosetDbContext context = new(options);
            SeedBranches(context);
        }

        static void SeedBranches(InfosetDbContext dbContext)
        {
            if (!dbContext.RestaurantBranches.Any())
            {
                dbContext.RestaurantBranches.AddRange(GetBranchesListForSeed());
                dbContext.SaveChanges();
            }
        }
        static List<Branch> GetBranchesListForSeed()
        {
            return new List<Branch>()
            {
              #region Branches
              new()
              {
                  Name = "Infoset Pizza Merkez Ofis",
                  Latitude= 40.949540734449776,
                  Longitude= 29.123631434317760,
              },
              new()
              {
                  Name = "Infoset Pizza Kadıköy",
                  Latitude= 40.9910086840072,
                  Longitude= 29.025588200110338,
              },
              new()
              {
                 Name = "Infoset Pizza Üsküdar",
                 Latitude= 41.02694742520576,
                 Longitude= 29.015970078182903,
              },
              new()
              {
                Name = "Infoset Pizza Maltepe",
                Latitude= 40.93310322117608,
                Longitude= 29.147565179280157,
              },
              new()
              {
                Name = "Infoset Pizza Tuzla",
                Latitude= 40.81654450011582,
                Longitude= 29.31746346162466,
              },
              new()
              {
                Name = "Infoset Pizza Beşiktaş",
                Latitude= 41.04225546746839,
                Longitude= 29.00956635603291,
              },
              new()
              {
                Name = "Infoset Pizza Taksim",
                Latitude= 41.03421384441127,
                Longitude= 28.98137187232796,
              },
              new()
              {
                Name = "Infoset Pizza Erenköy",
                Latitude= 40.97176947833923,
                Longitude= 29.073683010444608,
              },
              new()
              {
                Name = "Infoset Pizza Ümraniye",
                Latitude= 41.02695191366565,
                Longitude= 29.10536135594587,
              },
              new()
              {
                Name = "Infoset Pizza Kayışdağı",
                Latitude= 40.98350415885479,
                Longitude= 29.13543524954215,
              },
              new()
              {
                Name = "Infoset Pizza Nişantaşı",
                Latitude= 41.04795173736476,
                Longitude= 28.993224832236816,
              },
              new()
              {
                Name = "Infoset Pizza Çengelköy",
                Latitude = 41.05276631946978,
                Longitude =  29.052410846191126,
              },
              new()
              {
                Name = "Infoset Pizza Bebek",
                Latitude= 41.07902467229549,
                Longitude= 29.04494309077386,
              },
              new()
              {
                Name = "Infoset Pizza Kavacık",
                Latitude= 41.094889689751156,
                Longitude= 29.096964352176794,
              },
              new()
              {
                Name = "Infoset Pizza Pendik",
                Latitude= 41.094889689751156,
                Longitude= 29.096964352176794,
              },
              new()
              {
                Name = "Infoset Pizza Dudullu",
                Latitude= 41.00133774745561,
                Longitude= 29.14361501251549,
              },
              new()
              {
                Name = "Infoset Pizza Piazza AVM",
                Latitude= 40.91947084213494,
                Longitude= 29.166805170840682,
              },
              new()
              {
                Name = "Infoset Pizza Cevizli",
                Latitude= 40.90944525372526,
                Longitude= 29.15503543901941,
              },
              new()
              {
                Name = "Infoset Pizza Soğanlık",
                Latitude= 40.91383712680475,
                Longitude= 29.19575670454679,
              },
              new()
              {
                Name = "Infoset Pizza Dragos",
                Latitude= 40.90852670306759,
                Longitude= 29.1411534715571,
              },
              new()
              {
                Name = "Infoset Pizza Atalar",
                Latitude= 40.90259837252037,
                Longitude= 29.170805302844624,
              },
              new()
              {
                Name = "Infoset Pizza Akasya AVM ",
                Latitude= 41.002409006635126,
                Longitude= 29.054743009686096,
              },
              new()
              {
                Name = "Infoset Pizza Nautilus AVM ",
                Latitude= 41.00048097827451,
                Longitude= 29.033322158759947,
              },
              new()
              {
                Name = "Infoset Pizza Moda",
                Latitude= 40.980662725850486,
                Longitude= 29.02571441069155,
              },
              new()
              {
                Name = "Infoset Pizza Göztepe",
                Latitude= 40.97835199340279,
                Longitude= 29.061738745533596,
              },
              new()
              {
                Name = "Infoset Pizza Eminönü",
                Latitude = 41.013889312744140,
                Longitude = 28.96027946472168,
              },
              new()
              {
                Name = "Infoset Pizza Akaretler",
                Latitude = 41.042529037849870,
                Longitude = 29.000153425891686,
              },
              new()
              {
                Name = "Infoset Pizza Ataşehir DasDas",
                Latitude = 40.994552392079164,
                Longitude = 29.1254866247583136,
              },
              new()
              {
                Name = "Infoset Pizza Bostancı",
                Latitude = 40.952771050155310,
                Longitude = 29.096277794468918,
              },
              new()
              {
                Name = "Infoset Pizza Küçükyalı",
                Latitude = 40.946215412547722,
                Longitude = 29.110041309372246,
              },
              new()
              {
                Name = "Infoset Pizza Fatih",
                Latitude = 41.012299135033150,
                Longitude = 28.934469800375897,
              },
              new()
              {
                Name = "Infoset Pizza Ataköy",
                Latitude = 40.982883377049816,
                Longitude = 28.852820938078460,
              },
              new()
              {
                Name = "Infoset Pizza Bakırköy",
                Latitude = 40.973225339027381,
                Longitude = 28.852820938078460,
              },
              new()
              {
                Name = "Infoset Pizza Florya",
                Latitude = 40.972484248858911,
                Longitude = 28.792430739229430,
              },
              new()
              {
                Name = "Infoset Pizza Küçükçekmece",
                Latitude = 41.001841552360034,
                Longitude = 28.771645033177016,
              },
              new()
              {
                Name = "Infoset Pizza Maslak",
                Latitude = 41.112724006477364,
                Longitude = 29.022289459677886,
              },
              new()
              {
                Name = "Infoset Pizza UNIQ Istanbul",
                Latitude = 41.10808785337573,
                Longitude =29.007978738278354,
              },
              new()
              {
                Name = "Infoset Pizza Zekeriyaköy",
                Latitude = 41.185784948463620,
                Longitude =29.041311247807243,
              },
              #endregion
            };
        }

        /* Latitude           Longitude          Name
        * 40.949540734449776,29.123631434317760 Infoset Pizza Merkez Ofis
        * 40.991008684007320,29.025588200110338 Kadıköy
        * 41.026947425205760,29.015970078182903 Üsküdar
        * 41.042255467468390,29.009566356032910 Beşiktaş
        * 40.933103221176080,29.147565179280157 Maltepe
        * 41.034213844411270,28.981371872327960 Taksim
        * 40.816544500115820,29.317463461624660 Tuzla
        * 40.971769478339230,29.073683010444608 Erenköy
        * 41.026951913665650,29.105361355945870 Ümraniye
        * 40.983504158854790,29.135435249542150 Kayışdağı
        * 41.047951737364760,28.993224832236816 Nişantaşı
        * 41.052766319469780,29.052410846191126 Çengelköy
        * 41.079024672295490,29.044943090773867 Bebek
        * 41.094889689751156,29.096964352176794 Kavacık
        * 40.871767245456596,29.259433249883890 Pendik
        * 41.001337747455610,29.143615012515490 Dudullu
        * 40.919470842134940,29.166805170840682 Piazza AVM
        * 40.909445253725260,29.155035439019410 Cevizli
        * 40.913837126804750,29.195756704546790 Soğanlık
        * 40.908526703067590,29.141153471557100 Dragos
        * 40.902598372520370,29.170805302844624 Atalar
        * 41.002409006635126,29.054743009686096 Akasya AVM 
        * 41.000480978274510,29.033322158759947 Nautilus AVM
        * 40.980662725850486,29.025714410691551 Moda
        * 40.978351993402790,29.061738745533596 Göztepe
        * 41.013889312744140,28.960279464721681 Eminönü
        * 41.042529037849870,29.000153425891686 Akaretler
        * 40.994552392079164,29.125486624758313 Ataşehir DasDas
        * 40.952771050155310,29.096277794468918 Bostancı
        * 40.946215412547722,29.110041309372246 Küçükyalı
        * 41.012299135033150,28.934469800375897 Fatih
        * 40.982883377049816,28.852820938078460 Ataköy
        * 40.973225339027381,28.803144394320560 Bakırköy
        * 40.972484248858911,28.792430739229430 Florya
        * 41.001841552360034,28.771645033177016 Küçükçekmece
        * 41.112724006477364,29.022289459677886 Maslak
        * 41.108087853375731,29.007978738278354 UNIQ Istanbul
        * 41.185784948463620,29.041311247807243 Zekeriyaköy
        */
    }
}
