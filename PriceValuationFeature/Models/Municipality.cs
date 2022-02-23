using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceValuationFeature.Models
{
    public class Municipality
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

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }
    }
}
