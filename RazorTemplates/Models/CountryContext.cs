using Microsoft.EntityFrameworkCore;

namespace RazorTemplates.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options)
            : base(options) { }

        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().HasData(
                new Game { GameId = "win", GameName = "Winter Olympics" },
                new Game { GameId = "sum", GameName = "Summer Olympics" },
                new Game { GameId = "para", GameName = "Paralymics" },
                new Game { GameId = "youth", GameName = "Youth Olympic Games" });

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "curling", CategoryName = "Curling/Indoor" },
                new Category { CategoryId = "bobsleigh", CategoryName = "Bobsleigh/Outdoor" },
                new Category { CategoryId = "diving", CategoryName = "Diving/Indoor" },
                new Category { CategoryId = "cycling", CategoryName = "Road Cycling/Outdoor" },
                new Category { CategoryId = "archery", CategoryName = "Archery/Indoor" },
                new Category { CategoryId = "canoe", CategoryName = "Canoe Sprint/Outdoor" },
                new Category { CategoryId = "breakdancing", CategoryName = "Breakdancing/Indoor" },
                new Category { CategoryId = "skateboarding", CategoryName = "Skateboarding/Outdoor"}
                );

            modelBuilder.Entity<Country>().HasData(
                new { CountryId = "can", CountryName = "Canada", GameId = "win", CategoryId = "curling", CountryFlag = "CAN.png" },
                new { CountryId = "swe", CountryName = "Sweden", GameId = "win", CategoryId = "curling", CountryFlag = "SWE.png" },
                new { CountryId = "bri", CountryName = "Great Britain", GameId = "win", CategoryId = "curling", CountryFlag = "BRI.png" },
                new { CountryId = "jam", CountryName = "Jamaica", GameId = "win", CategoryId = "bobsleigh", CountryFlag = "JAM.png" },
                new { CountryId = "ita", CountryName = "Italy", GameId = "win", CategoryId = "bobsleigh", CountryFlag = "ITA.png" },
                new { CountryId = "jap", CountryName = "Japan", GameId = "win", CategoryId = "bobsleigh", CountryFlag = "JAP.png" },
                new { CountryId = "ger", CountryName = "Germany", GameId = "sum", CategoryId = "diving", CountryFlag = "GER.png" },
                new { CountryId = "chi", CountryName = "China", GameId = "sum", CategoryId = "diving", CountryFlag = "CHI.png" },
                new { CountryId = "mex", CountryName = "Mexico", GameId = "sum", CategoryId = "diving", CountryFlag = "MEX.png" },
                new { CountryId = "bra", CountryName = "Brazil", GameId = "sum", CategoryId = "cycling", CountryFlag = "BRA.png" },
                new { CountryId = "net", CountryName = "Netherlands", GameId = "sum", CategoryId = "cycling", CountryFlag = "NET.png" },
                new { CountryId = "usa", CountryName = "USA", GameId = "sum", CategoryId = "cycling", CountryFlag = "USA.png" },
                new { CountryId = "tha", CountryName = "Thailand", GameId = "para", CategoryId = "archery", CountryFlag = "THA.png" },
                new { CountryId = "uru", CountryName = "Uruguay", GameId = "para", CategoryId = "archery", CountryFlag = "URU.png" },
                new { CountryId = "ukr", CountryName = "Ukraine", GameId = "para", CategoryId = "archery", CountryFlag = "UKR.png" },
                new { CountryId = "aus", CountryName = "Austria", GameId = "para", CategoryId = "canoe", CountryFlag = "AUS.png" },
                new { CountryId = "pak", CountryName = "Pakistan", GameId = "para", CategoryId = "canoe", CountryFlag = "PAK.png" },
                new { CountryId = "zim", CountryName = "Zimbabwe", GameId = "para", CategoryId = "canoe", CountryFlag = "ZIM.png" },
                new { CountryId = "fra", CountryName = "France", GameId = "youth", CategoryId = "breakdancing", CountryFlag = "FRA.png" },
                new { CountryId = "cyp", CountryName = "Cyprus", GameId = "youth", CategoryId = "breakdancing", CountryFlag = "CYP.png" },
                new { CountryId = "rus", CountryName = "Russia", GameId = "youth", CategoryId = "breakdancing", CountryFlag = "RUS.png" },
                new { CountryId = "fin", CountryName = "Finland", GameId = "youth", CategoryId = "skateboarding", CountryFlag = "FIN.png" },
                new { CountryId = "slo", CountryName = "Slovakia", GameId = "youth", CategoryId = "skateboarding", CountryFlag = "SLO.png" },
                new { CountryId = "por", CountryName = "Portugal", GameId = "youth", CategoryId = "skateboarding", CountryFlag = "POR.png" }
                );
        }
    }
    
}
