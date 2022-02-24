using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PriceValuationFeature.Models;

namespace PriceValuationFeature.Managers
{
    public class PriceValuationFeatureManager
    {
        private static int _nextId = 1;

        private static List<Home> homes = new List<Home>()
        {
            new Home(){Id = _nextId++, MunicipalityId = 1, IsOpen = true, Price = 6000000, Kvm = 150, DaysForSale = 180},
            new Home(){Id = _nextId++, MunicipalityId = 1, IsOpen = false, Price = 4000000,  Kvm = 100, DaysForSale = 127},
            new Home(){Id = _nextId++, MunicipalityId = 1, IsOpen = false, Price = 5000000,  Kvm = 75, DaysForSale = 60},
            new Home(){Id = _nextId++, MunicipalityId = 2, IsOpen = false, Price = 3000000,  Kvm = 125, DaysForSale = 210},
            new Home(){Id = _nextId++, MunicipalityId = 2, IsOpen = true, Price = 1000000,  Kvm = 75, DaysForSale = 50},
            new Home(){Id = _nextId++, MunicipalityId = 2, IsOpen = true, Price = 2750000,  Kvm = 115, DaysForSale = 70}
        };

        private static List<Municipality> municipalities = new List<Municipality>()
        {
            new Municipality(){Id = 1, Name = "Frederiksberg"},
            new Municipality(){Id = 2, Name = "Roskilde"}
        };

        public List<Home> GetAll(string sortBy = null)
        {
            List<Home> homesList = new List<Home>(homes);
            if (sortBy != null)
            {
                switch (sortBy)
                {
                    case "price":
                        homesList = homesList.OrderByDescending(home => home.Price).ToList();
                        break;
                    case "kvm":
                        homesList = homesList.OrderByDescending(home => home.Kvm).ToList();
                        break;
                    case "daysforsale":
                        homesList = homesList.OrderByDescending(home => home.DaysForSale).ToList();
                        break;
                }
            }
            return homesList;
        }

        public Home GetById(int id)
        {
            return homes.Find(home => home.Id == id);
        }

        public int TotalHomesForSaleInMunicipality(int municipalityId)
        {
            return homes.Where(x => x.MunicipalityId == municipalityId).Count(x => x.IsOpen);
        }

        public double AvgKvmPriceInMunicipality(int municipalityId)
        {
            double d = homes.Where(x => x.MunicipalityId == municipalityId).Select(x => x.AvgKvmPrice()).Average();
            double dc = Math.Round((double)d, 0);
            return dc;
        }

        public double AvgKvmPriceInMunicipality2()
        {
            double d = homes.Where(x => x.MunicipalityId == 2).Select(x => x.AvgKvmPrice()).Average();
            double dc = Math.Round((double)d, 0);
            return dc;
        }

        public double AvgDaysForSaleInMunicipality()
        {
            return homes.Where(x => x.MunicipalityId == 1 && x.IsOpen == false).Select(x => x.DaysForSale).Average();
        }
    }
}
