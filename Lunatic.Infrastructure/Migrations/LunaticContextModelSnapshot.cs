﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Lunatic.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lunatic.Infrastructure.Migrations
{
    [DbContext(typeof(LunaticContext))]
    partial class LunaticContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Lunatic.Domain.Entities.Book", b =>
                {
                    b.Property<Guid>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Genres")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<Guid>>("Ratings")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Lunatic.Domain.Entities.BookClub", b =>
                {
                    b.Property<Guid>("BookClubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<List<Guid>>("Books")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<Guid>>("Members")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BookClubId");

                    b.ToTable("BookClubs");
                });

            modelBuilder.Entity("Lunatic.Domain.Entities.CoverImage", b =>
                {
                    b.Property<Guid>("CoverImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CoverImageId");

                    b.ToTable("CoverImages");
                });

            modelBuilder.Entity("Lunatic.Domain.Entities.FriendRecommandation", b =>
                {
                    b.Property<Guid>("FriendRecommandationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uuid");

                    b.HasKey("FriendRecommandationId");

                    b.ToTable("FriendRecommandation");
                });

            modelBuilder.Entity("Lunatic.Domain.Entities.FriendRequest", b =>
                {
                    b.Property<Guid>("FriendRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("FriendRequestId");

                    b.ToTable("FriendRequest");
                });

            modelBuilder.Entity("Lunatic.Domain.Entities.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("LastModifiedByUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<string>>("TaskSections")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Lunatic.Domain.Entities.Rating", b =>
                {
                    b.Property<Guid>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<string>("CommentMessage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Score")
                        .HasColumnType("real");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("RatingId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("Lunatic.Domain.Entities.Reader", b =>
                {
                    b.Property<Guid>("ReaderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("boolean");

                    b.Property<Guid>("RatingId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("ReaderId");

                    b.ToTable("Readers");
                });

            modelBuilder.Entity("Lunatic.Domain.Entities.Team", b =>
                {
                    b.Property<Guid>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("LastModifiedByUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<Guid>>("MemberIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<Guid>>("ProjectIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Lunatic.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<List<Guid>>("BookClubIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<Guid>>("FavoriteIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<Guid>>("FriendsIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<List<Guid>>("FriendsRequests")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<Guid>>("ReaderIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<Guid>>("WantToReadIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
