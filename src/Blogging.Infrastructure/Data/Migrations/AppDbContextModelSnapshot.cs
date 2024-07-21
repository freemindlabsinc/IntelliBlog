﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Blogging.Infrastructure.Data.Migrations
{
    [DbContext(typeof(BloggingDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence<int>("General_seq")
                .StartsAt(0L);

            modelBuilder.Entity("Blogging.Domain.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR General_seq");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Description")
                        .HasMaxLength(-1)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Notes")
                        .HasMaxLength(-1)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Blogging.Domain.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR General_seq");

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasMaxLength(-1)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Blogging.Domain.PostComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CommentedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommentedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("PostComments", (string)null);
                });

            modelBuilder.Entity("Blogging.Domain.PostCommentLike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LikedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LikedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostCommentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostCommentId");

                    b.ToTable("PostCommentLikes", (string)null);
                });

            modelBuilder.Entity("Blogging.Domain.PostLike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LikedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("LikedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("PostLikes", (string)null);
                });

            modelBuilder.Entity("Blogging.Domain.PostSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LinkedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("SourceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("SourceId");

                    b.ToTable("PostSources", (string)null);
                });

            modelBuilder.Entity("Blogging.Domain.Source", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR General_seq");

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Description")
                        .HasMaxLength(-1)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("Sources");
                });

            modelBuilder.Entity("Blogging.Domain.SourceComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CommentedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommentedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("SourceId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SourceId");

                    b.ToTable("SourceComments");
                });

            modelBuilder.Entity("Blogging.Domain.SourceLike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LikedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LikedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("SourceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SourceId");

                    b.ToTable("SourceLikes");
                });

            modelBuilder.Entity("Blogging.Domain.Post", b =>
                {
                    b.HasOne("Blogging.Domain.Blog", null)
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blogging.Domain.PostComment", b =>
                {
                    b.HasOne("Blogging.Domain.Post", null)
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blogging.Domain.PostCommentLike", b =>
                {
                    b.HasOne("Blogging.Domain.PostComment", null)
                        .WithMany("Likes")
                        .HasForeignKey("PostCommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blogging.Domain.PostLike", b =>
                {
                    b.HasOne("Blogging.Domain.Post", null)
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blogging.Domain.PostSource", b =>
                {
                    b.HasOne("Blogging.Domain.Post", null)
                        .WithMany("Sources")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Blogging.Domain.Source", null)
                        .WithMany()
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Blogging.Domain.Source", b =>
                {
                    b.HasOne("Blogging.Domain.Blog", null)
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blogging.Domain.SourceComment", b =>
                {
                    b.HasOne("Blogging.Domain.Source", null)
                        .WithMany()
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blogging.Domain.SourceLike", b =>
                {
                    b.HasOne("Blogging.Domain.Source", null)
                        .WithMany("Likes")
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blogging.Domain.Post", b =>
                {
                    b.Navigation("Likes");

                    b.Navigation("Sources");
                });

            modelBuilder.Entity("Blogging.Domain.PostComment", b =>
                {
                    b.Navigation("Likes");
                });

            modelBuilder.Entity("Blogging.Domain.Source", b =>
                {
                    b.Navigation("Likes");
                });
#pragma warning restore 612, 618
        }
    }
}
