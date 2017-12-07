using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity;

namespace FinalProject.Models
{
    public partial class FinalContext : DbContext
    {
        public FinalContext() : base("name=FinalContext")
        { }

        public virtual DbSet<Cast> Casts { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Director> Directors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //'The model backing the context has changed since the database was created
            //Fixed!
            //Database.SetInitializer<AuctionContext>(null);
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Director)
                .IsUnicode(false);

            modelBuilder.Entity<Director>()
                .HasMany(e => e.Movies)
                .WithOptional(e => e.Director1)
                .HasForeignKey(e => e.Director);

            modelBuilder.Entity<Actor>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Director>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Cast>()
                .Property(e => e.Actor)
                .IsUnicode(false);

            modelBuilder.Entity<Actor>()
                .HasMany(e => e.Casts)
                .WithOptional(e => e.Actor1)
                .HasForeignKey(e => e.Actor);

            modelBuilder.Entity<Cast>()
                .Property(e => e.Movie)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Casts)
                .WithOptional(e => e.Movie1)
                .HasForeignKey(e => e.Movie);

            //modelBuilder.Entity<Movie>()
            //    .HasMany(e => e.Actors)
            //    .WithMany(e => e.Movies)
            //    .Map(m => m.ToTable("Casts").MapLeftKey("Movie").MapRightKey("Actor"));
        }

    }
}