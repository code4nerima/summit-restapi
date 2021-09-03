﻿// <auto-generated />
using System;
using CfjSummit.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CfjSummit.WebApi.Migrations
{
    [DbContext(typeof(CfjContext))]
    [Migration("20210903142419_Chg-2021-09-03-03")]
    partial class Chg2021090303
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.Genre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("GenreGuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name_En")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Ja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Zh_Cn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Zh_Tw")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.Program", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BroadcastingURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description_En")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description_Ja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description_Zh_Cn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description_Zh_Tw")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InputCompleted")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PresentationURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProgramCategory")
                        .HasColumnType("int");

                    b.Property<string>("ProgramGuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Title_En")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title_Ja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title_Zh_Cn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title_Zh_Tw")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("TrackId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TrackId");

                    b.ToTable("Programs");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.ProgramGenre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("GenreId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("ProgramId")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("ProgramId");

                    b.ToTable("ProgramGenres");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.ProgramGrareco", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description_En")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description_Ja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description_Zh_Cn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description_Zh_Tw")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name_En")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Ja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Ja_Kana")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Zh_Cn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Zh_Tw")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization_En")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization_Ja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization_Zh_Cn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization_Zh_Tw")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgramGrarecoGuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ProgramId")
                        .HasColumnType("bigint");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.ToTable("ProgramGrareco");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.ProgramLink", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ProgramId")
                        .HasColumnType("bigint");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Title_En")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title_Ja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title_Zh_Cn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title_Zh_Tw")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.ToTable("ProgramLinks");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.ProgramPresenter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description_En")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description_Ja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description_Zh_Cn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description_Zh_Tw")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name_En")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Ja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Ja_Kana")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Zh_Cn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Zh_Tw")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization_En")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization_Ja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization_Zh_Cn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization_Zh_Tw")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ProgramId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProgramPresenterGuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.ToTable("ProgramPresenters");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.ProgramPresenterLink", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ProgramPresenterId")
                        .HasColumnType("bigint");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Title_En")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title_Ja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title_Zh_Cn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title_Zh_Tw")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProgramPresenterId");

                    b.ToTable("ProgramPresenterLinks");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.ProgramUserProfile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("ProgramId")
                        .HasColumnType("bigint");

                    b.Property<int>("ProgramRole")
                        .HasColumnType("int");

                    b.Property<int>("StaffRole")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<long>("UserProfileId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("ProgramUserProfiles");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.RequestLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Controller")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LocalIpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Method")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("RemoteIpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Uid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RequestLogs");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.Track", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BroadcastingURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BroadcastingURL_1stDay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BroadcastingURL_2ndDay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("MeetingId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeetingPasscode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeetingUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Memo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name_En")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Ja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Zh_Cn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Zh_Tw")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Station")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreamKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreamUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("TrackGuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UdTalkAppURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UdTalkWebURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UdtalkSrURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.UserProfile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name_En")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Ja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Ja_Kana")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Zh_Cn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Zh_Tw")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.Program", b =>
                {
                    b.HasOne("CfjSummit.Domain.Models.Entities.Track", "Track")
                        .WithMany("Programs")
                        .HasForeignKey("TrackId");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.ProgramGenre", b =>
                {
                    b.HasOne("CfjSummit.Domain.Models.Entities.Genre", "Genre")
                        .WithMany("ProgramGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CfjSummit.Domain.Models.Entities.Program", "Program")
                        .WithMany("ProgramGenres")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Program");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.ProgramGrareco", b =>
                {
                    b.HasOne("CfjSummit.Domain.Models.Entities.Program", "Program")
                        .WithMany("ProgramGrarecos")
                        .HasForeignKey("ProgramId");

                    b.Navigation("Program");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.ProgramLink", b =>
                {
                    b.HasOne("CfjSummit.Domain.Models.Entities.Program", "Program")
                        .WithMany("ProgramLinks")
                        .HasForeignKey("ProgramId");

                    b.Navigation("Program");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.ProgramPresenter", b =>
                {
                    b.HasOne("CfjSummit.Domain.Models.Entities.Program", "Program")
                        .WithMany("ProgramPresenters")
                        .HasForeignKey("ProgramId");

                    b.Navigation("Program");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.ProgramPresenterLink", b =>
                {
                    b.HasOne("CfjSummit.Domain.Models.Entities.ProgramPresenter", "ProgramPresenter")
                        .WithMany("ProgramPresenterLinks")
                        .HasForeignKey("ProgramPresenterId");

                    b.Navigation("ProgramPresenter");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.ProgramUserProfile", b =>
                {
                    b.HasOne("CfjSummit.Domain.Models.Entities.Program", "Program")
                        .WithMany("ProgramUserProfiles")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CfjSummit.Domain.Models.Entities.UserProfile", "UserProfile")
                        .WithMany("ProgramUserProfiles")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Program");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.Genre", b =>
                {
                    b.Navigation("ProgramGenres");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.Program", b =>
                {
                    b.Navigation("ProgramGenres");

                    b.Navigation("ProgramGrarecos");

                    b.Navigation("ProgramLinks");

                    b.Navigation("ProgramPresenters");

                    b.Navigation("ProgramUserProfiles");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.ProgramPresenter", b =>
                {
                    b.Navigation("ProgramPresenterLinks");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.Track", b =>
                {
                    b.Navigation("Programs");
                });

            modelBuilder.Entity("CfjSummit.Domain.Models.Entities.UserProfile", b =>
                {
                    b.Navigation("ProgramUserProfiles");
                });
#pragma warning restore 612, 618
        }
    }
}
