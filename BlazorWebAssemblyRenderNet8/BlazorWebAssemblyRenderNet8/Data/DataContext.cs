using BlazorWebAssemblyRenderNet8.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAssemblyRenderNet8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base (options)
        {
        }

        public DbSet<VideoGame> VideoGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame
                {
                    Id = 1,
                    Title = "Cyberpunk 2077",
                    Publisher = "CD Projekt",
                    ReleaseYear = 2020
                },
                new VideoGame
                {
                    Id = 2,
                    Title = "Elden Ring",
                    Publisher = "From Software",
                    ReleaseYear = 2022
                },
                new VideoGame
                {
                    Id = 3,
                    Title = "The Leyend of Zelda",
                    Publisher = "Nintendo",
                    ReleaseYear = 1998
                }

                );
        }

    }
}
