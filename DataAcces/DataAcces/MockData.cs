using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace DataAccess
{
    public static class SeedDataExtensions
    {
        public static void SeedPhones(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Laptop>().HasData(new Laptop[]
            {
                new Laptop()
                {
                    Id = 1,
                    Model = "Assus",
                    Color = "Midnight",
                    MemoryId = (int)Memories.Smal,
                    Price = 8799,
                    Description = "A total powerhouse."
                },
                new Laptop()
                {
                    Id = 2,
                    Model = "Accer",
                    Color = "Starlight",
                    MemoryId = (int)Memories.Smal,
                    Price = 9899,
                    Description = "Big and bigger."
                },
                new Laptop()
                {
                    Id = 3,
                    Model = "Lenovo",
                    Color = "SpaceBlack",
                    MemoryId = (int)Memories.Ser,
                    Price = 11099,
                    Description = "The ultimate Laptop."
                },
                new Laptop()
                {
                    Id = 4,
                    Model = "Legion 5",
                    Color = "DeepPurple",
                    MemoryId = (int)Memories.Big,
                    Price = 11399,
                    Description = "Pro. Beyond."
                }
            });
        }
        public static void SeedColors(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Memory>().HasData(new Memory[]
            {
                new Memory() { Id = (int)Memories.Smal, Name = "128 Gb" },
                new Memory() { Id = (int)Memories.Ser, Name = "250 Gb" },
                new Memory() { Id = (int)Memories.Big, Name = "520 Gb" }
            });
        }
    }
}