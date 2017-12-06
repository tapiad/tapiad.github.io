using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AuctionHouse.DAL
{
    public partial class AuctionContext : DbContext
    {
        public AuctionContext() : base("name=AuctionContext")
        { }

        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
    }
}