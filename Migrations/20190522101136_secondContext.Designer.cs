﻿// <auto-generated />
using System;
using Core2_2ApiJwt.Context.DbOperation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core2_2ApiJwt.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190522101136_secondContext")]
    partial class secondContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core2_2ApiJwt.Entities.Entity+Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertDate");

                    b.Property<int>("Score");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("Core2_2ApiJwt.Entities.Entity+Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Key");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Core2_2ApiJwt.Entities.Entity+WordDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("LanguageTypeId");

                    b.Property<int>("WordsId");

                    b.HasKey("Id");

                    b.ToTable("WordDescriptions");
                });

            modelBuilder.Entity("Core2_2ApiJwt.Entities.Entity+WordSampleSentences", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SampleSentences");

                    b.Property<int>("WordId");

                    b.HasKey("Id");

                    b.ToTable("WordSampleSentencess");
                });

            modelBuilder.Entity("Core2_2ApiJwt.Entities.Entity+WordType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("WordTypes");
                });

            modelBuilder.Entity("Core2_2ApiJwt.Entities.Entity+Words", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Word");

                    b.Property<int>("WordTypeId");

                    b.HasKey("Id");

                    b.ToTable("Wordss");
                });

            modelBuilder.Entity("Core2_2ApiJwt.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
