using System;

#nullable disable

namespace ChallengeDataObjects.Context
{
    public partial class Product
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public double Value { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ProductType TypeNavigation { get; set; }
    }
}
