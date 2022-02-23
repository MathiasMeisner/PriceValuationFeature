using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceValuationFeature.Models
{
    public class Home
    {
        private int _id;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
            }
        }

        private int _municipalityId;

        public int MunicipalityId
        {
            get => _municipalityId;
            set
            {
                _municipalityId = value;
            }
        }

        private bool _isOpen;

        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                _isOpen = value;
            }
        }

        private int _price;

        public int Price
        {
            get => _price;
            set
            {
                _price = value;
            }
        }

        private int _kvm;

        public int Kvm
        {
            get => _kvm;
            set
            {
                _kvm = value;
            }
        }

        private int _daysForSale;

        public int DaysForSale
        {
            get => _daysForSale;
            set
            {
                _daysForSale = value;
            }
        }

        public int AvgKvmPrice()
        {
            return (Price / Kvm);
        }
    }
}
