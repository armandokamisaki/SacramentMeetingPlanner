﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SacramentMeetingPlanner.Data;

namespace SacramentMeetingPlanner.Migrations
{
    [DbContext(typeof(PlannerContext))]
    partial class PlannerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Hymn", b =>
                {
                    b.Property<int>("HymnID")
                        .HasColumnType("int");

                    b.Property<string>("HymnName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HymnID");

                    b.ToTable("Hymn");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberId");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Planner", b =>
                {
                    b.Property<int>("PlannerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Hymn1ID")
                        .HasColumnType("int");

                    b.Property<int>("Hymn2ID")
                        .HasColumnType("int");

                    b.Property<int>("Hymn3ID")
                        .HasColumnType("int");

                    b.Property<int?>("Hymn4ID")
                        .HasColumnType("int");

                    b.Property<int?>("HymnID")
                        .HasColumnType("int");

                    b.Property<int>("Member1ID")
                        .HasColumnType("int");

                    b.Property<int>("Member2ID")
                        .HasColumnType("int");

                    b.Property<int>("Member3ID")
                        .HasColumnType("int");

                    b.Property<int>("Member4ID")
                        .HasColumnType("int");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("SpecialHymn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlannerID");

                    b.HasIndex("HymnID");

                    b.HasIndex("MemberId");

                    b.ToTable("Planner");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Speaker", b =>
                {
                    b.Property<int>("SpeakerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.Property<int>("PlannerID")
                        .HasColumnType("int");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpeakerID");

                    b.HasIndex("MemberID");

                    b.HasIndex("PlannerID");

                    b.ToTable("Speaker");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Planner", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.Hymn", "Hymn")
                        .WithMany()
                        .HasForeignKey("HymnID");

                    b.HasOne("SacramentMeetingPlanner.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");

                    b.Navigation("Hymn");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Speaker", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SacramentMeetingPlanner.Models.Planner", "Planner")
                        .WithMany("Speakers")
                        .HasForeignKey("PlannerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Planner");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Planner", b =>
                {
                    b.Navigation("Speakers");
                });
#pragma warning restore 612, 618
        }
    }
}
