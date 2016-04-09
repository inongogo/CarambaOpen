using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using CarambaOpen.DbContexts;

namespace CarambaOpen.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarambaOpen.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alt1")
                        .IsRequired();

                    b.Property<string>("Alt2")
                        .IsRequired();

                    b.Property<string>("Alt3")
                        .IsRequired();

                    b.Property<string>("Alt4")
                        .IsRequired();

                    b.Property<int?>("PollId")
                        .IsRequired();

                    b.Property<int?>("QuestionId")
                        .IsRequired();

                    b.HasKey("Id");
                });

            modelBuilder.Entity("CarambaOpen.Models.Destination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CarRentalCost");

                    b.Property<string>("Cons");

                    b.Property<string>("DestinationCity");

                    b.Property<string>("DestinationCountry");

                    b.Property<int>("FoodDrinkCost");

                    b.Property<string>("GolfClub1Name");

                    b.Property<string>("GolfClub1Url");

                    b.Property<string>("GolfClub2Name");

                    b.Property<string>("GolfClub2Url");

                    b.Property<string>("GolfClub3Name");

                    b.Property<string>("GolfClub3Url");

                    b.Property<int>("GolfCost");

                    b.Property<string>("HotellName");

                    b.Property<string>("HotellUrl");

                    b.Property<int>("LivingCost");

                    b.Property<string>("LivingType");

                    b.Property<string>("Pros");

                    b.Property<int>("TravelCost");

                    b.Property<string>("TravelType");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("CarambaOpen.Models.Poll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");
                });

            modelBuilder.Entity("CarambaOpen.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alt1");

                    b.Property<string>("Alt2");

                    b.Property<string>("Alt3");

                    b.Property<string>("Alt4");

                    b.Property<int>("Order");

                    b.Property<string>("Quest");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("CarambaOpen.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Id");
                });

            modelBuilder.Entity("CarambaOpen.Models.Answer", b =>
                {
                    b.HasOne("CarambaOpen.Models.Poll")
                        .WithMany()
                        .HasForeignKey("PollId");

                    b.HasOne("CarambaOpen.Models.Question")
                        .WithMany()
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("CarambaOpen.Models.Poll", b =>
                {
                    b.HasOne("CarambaOpen.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
