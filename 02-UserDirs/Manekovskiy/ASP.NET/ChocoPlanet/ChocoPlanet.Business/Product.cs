using System;

namespace ChocoPlanet.Business
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public string ThumbnailName { get; set; }

        public double Price { get; set; }
        public DateTime? PlacementDate { get; set; } 
    }
}