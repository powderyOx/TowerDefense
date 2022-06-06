﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.Configurations;

#nullable disable

namespace Model.Migrations
{
    [DbContext(typeof(TowerDbContext))]
    [Migration("20220606193902_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Entities.AEntity", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ENTITY_ID");

                    b.Property<int>("Damage")
                        .HasColumnType("int")
                        .HasColumnName("DAMAGE");

                    b.Property<string>("EntityType")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("ENTITY_TYPE");

                    b.HasKey("EntityId");

                    b.ToTable("ENTITIES_BT");
                });

            modelBuilder.Entity("Model.Entities.GameMap", b =>
                {
                    b.Property<int>("MapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MAP_ID");

                    b.HasKey("MapId");

                    b.ToTable("MAPS");
                });

            modelBuilder.Entity("Model.Entities.Map.AField", b =>
                {
                    b.Property<int>("X")
                        .HasColumnType("int")
                        .HasColumnName("X");

                    b.Property<int>("Y")
                        .HasColumnType("int")
                        .HasColumnName("Y");

                    b.Property<string>("FIELD_TYPE")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MapId")
                        .HasColumnType("int")
                        .HasColumnName("MAP_ID");

                    b.HasKey("X", "Y");

                    b.HasIndex("MapId");

                    b.ToTable("FIELDS_ST");

                    b.HasDiscriminator<string>("FIELD_TYPE").HasValue("AField");
                });

            modelBuilder.Entity("Model.Entities.MapEntity", b =>
                {
                    b.Property<int>("MapEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MAP_ENTITY_ID");

                    b.Property<int>("EntityId")
                        .HasColumnType("int")
                        .HasColumnName("ENTITY_ID");

                    b.Property<int>("SavedGameId")
                        .HasColumnType("int")
                        .HasColumnName("SAVED_GAME_ID");

                    b.Property<int?>("StartIndex")
                        .HasColumnType("int")
                        .HasColumnName("START_INDEX");

                    b.Property<int?>("X")
                        .HasColumnType("int")
                        .HasColumnName("X");

                    b.Property<int?>("Y")
                        .HasColumnType("int")
                        .HasColumnName("Y");

                    b.HasKey("MapEntityId");

                    b.HasIndex("EntityId");

                    b.HasIndex("SavedGameId");

                    b.ToTable("MAP_HAS_ENTITIES_JT");
                });

            modelBuilder.Entity("Model.Entities.Round", b =>
                {
                    b.Property<int>("RoundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ROUND_ID");

                    b.HasKey("RoundId");

                    b.ToTable("ROUNDS");
                });

            modelBuilder.Entity("Model.Entities.SavedGame", b =>
                {
                    b.Property<int>("SavedGameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SAVED_GAME_ID");

                    b.Property<int>("HP")
                        .HasColumnType("int")
                        .HasColumnName("HP");

                    b.Property<int>("MapId")
                        .HasColumnType("int")
                        .HasColumnName("MAP_ID");

                    b.Property<int>("Money")
                        .HasColumnType("int")
                        .HasColumnName("MONEY");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("NAME");

                    b.Property<int>("Round")
                        .HasColumnType("int")
                        .HasColumnName("ROUND");

                    b.HasKey("SavedGameId");

                    b.HasIndex("MapId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("SAVED_GAMES");
                });

            modelBuilder.Entity("Model.Entities.Attacker", b =>
                {
                    b.HasBaseType("Model.Entities.AEntity");

                    b.Property<int>("Hp")
                        .HasColumnType("int")
                        .HasColumnName("HP");

                    b.Property<int>("Loot")
                        .HasColumnType("int")
                        .HasColumnName("LOOT");

                    b.Property<int>("RoundId")
                        .HasColumnType("int")
                        .HasColumnName("ROUND_ID");

                    b.Property<int>("Shield")
                        .HasColumnType("int")
                        .HasColumnName("SHIELD");

                    b.Property<int>("Speed")
                        .HasColumnType("int")
                        .HasColumnName("SPEED");

                    b.HasIndex("RoundId");

                    b.ToTable("ATTACKERS");
                });

            modelBuilder.Entity("Model.Entities.Defender", b =>
                {
                    b.HasBaseType("Model.Entities.AEntity");

                    b.Property<int>("Cost")
                        .HasColumnType("int")
                        .HasColumnName("COST");

                    b.Property<int>("FireRate")
                        .HasColumnType("int")
                        .HasColumnName("FIRE_RATE");

                    b.Property<int>("Range")
                        .HasColumnType("int")
                        .HasColumnName("RANGE");

                    b.Property<int>("Round")
                        .HasColumnType("int")
                        .HasColumnName("ROUND");

                    b.ToTable("DEFENDERS");
                });

            modelBuilder.Entity("Model.Entities.Map.FieldTypes.DownLeftTurn", b =>
                {
                    b.HasBaseType("Model.Entities.Map.AField");

                    b.ToTable("FIELDS_ST");

                    b.HasDiscriminator().HasValue("DOWN_LEFT_TURN");
                });

            modelBuilder.Entity("Model.Entities.Map.FieldTypes.DownRightTurn", b =>
                {
                    b.HasBaseType("Model.Entities.Map.AField");

                    b.ToTable("FIELDS_ST");

                    b.HasDiscriminator().HasValue("DOWN_RIGHT_TURN");
                });

            modelBuilder.Entity("Model.Entities.Map.FieldTypes.EmptyField", b =>
                {
                    b.HasBaseType("Model.Entities.Map.AField");

                    b.ToTable("FIELDS_ST");

                    b.HasDiscriminator().HasValue("EMPTY_FIELD");
                });

            modelBuilder.Entity("Model.Entities.Map.FieldTypes.HorizontalStraight", b =>
                {
                    b.HasBaseType("Model.Entities.Map.AField");

                    b.ToTable("FIELDS_ST");

                    b.HasDiscriminator().HasValue("HORIZONTAL_STRAIGHT");
                });

            modelBuilder.Entity("Model.Entities.Map.FieldTypes.UpLeftTurn", b =>
                {
                    b.HasBaseType("Model.Entities.Map.AField");

                    b.ToTable("FIELDS_ST");

                    b.HasDiscriminator().HasValue("UP_LEFT_TURN");
                });

            modelBuilder.Entity("Model.Entities.Map.FieldTypes.UpRightTurn", b =>
                {
                    b.HasBaseType("Model.Entities.Map.AField");

                    b.ToTable("FIELDS_ST");

                    b.HasDiscriminator().HasValue("UP_RIGHT_TURN");
                });

            modelBuilder.Entity("Model.Entities.Map.FieldTypes.VerticalStraight", b =>
                {
                    b.HasBaseType("Model.Entities.Map.AField");

                    b.ToTable("FIELDS_ST");

                    b.HasDiscriminator().HasValue("VERTICAL_STRAIGHT");
                });

            modelBuilder.Entity("Model.Entities.Map.AField", b =>
                {
                    b.HasOne("Model.Entities.GameMap", "Map")
                        .WithMany("Fields")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Map");
                });

            modelBuilder.Entity("Model.Entities.MapEntity", b =>
                {
                    b.HasOne("Model.Entities.AEntity", "AEntity")
                        .WithMany("MapEntities")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.SavedGame", "SavedGame")
                        .WithMany("MapEntities")
                        .HasForeignKey("SavedGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AEntity");

                    b.Navigation("SavedGame");
                });

            modelBuilder.Entity("Model.Entities.SavedGame", b =>
                {
                    b.HasOne("Model.Entities.GameMap", "Map")
                        .WithMany()
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Map");
                });

            modelBuilder.Entity("Model.Entities.Attacker", b =>
                {
                    b.HasOne("Model.Entities.AEntity", null)
                        .WithOne()
                        .HasForeignKey("Model.Entities.Attacker", "EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Round", "Round")
                        .WithMany()
                        .HasForeignKey("RoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Round");
                });

            modelBuilder.Entity("Model.Entities.Defender", b =>
                {
                    b.HasOne("Model.Entities.AEntity", null)
                        .WithOne()
                        .HasForeignKey("Model.Entities.Defender", "EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entities.AEntity", b =>
                {
                    b.Navigation("MapEntities");
                });

            modelBuilder.Entity("Model.Entities.GameMap", b =>
                {
                    b.Navigation("Fields");
                });

            modelBuilder.Entity("Model.Entities.SavedGame", b =>
                {
                    b.Navigation("MapEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
