﻿using Geocoding;

namespace Greedy.Domain.Shops
{
    public class Shop
    {
        public string Name { get; set; }

        public Location Location { get; set; }

        public string Address { get; set; }

        public string SubName { get; set; } // needs for additional possible name
    }
}