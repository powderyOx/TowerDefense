using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Entities.EntityTypes;
using Model.Entities.Map;
using Model.Entities.Map.FieldTypes;


namespace Model.Configurations; 

public class TowerDbContext : DbContext {
    
    public DbSet<Attacker> Attackers { get; set; }
    public DbSet<Defender> Defenders { get; set; }
    public DbSet<AEntity> Entities { get; set; }
    public DbSet<GameMap> Maps { get; set; }
    public DbSet<MapEntity> MapEntities { get; set; }
    public DbSet<SavedGame> SavedGames { get; set; }
    public DbSet<Round> Rounds { get; set; }
    public DbSet<AField> Fields { get; set; }
    
    //Fields
    public DbSet<DownLeftTurn> DownLeftTurns { get; set; }
    public DbSet<DownRightTurn> DownRightTurns { get; set; }
    public DbSet<EmptyField> EmptyFields { get; set; }
    public DbSet<HorizontalStraight> HorizontalStraights { get; set; }
    public DbSet<UpLeftTurn> UpLeftTurns { get; set; }
    public DbSet<UpRightTurn> UpRightTurns { get; set; }
    public DbSet<VerticalStraight> VerticalStraights { get; set; }

    //Defenders
    public DbSet<Archer> Archers { get; set; }
    public DbSet<LongbowArcher> LongbowArchers { get; set; }
    
    //Attackers
    public DbSet<Oni> Onis { get; set; }

    
    public TowerDbContext(DbContextOptions<TowerDbContext> dbContextOptions) : base(dbContextOptions) { }

    protected override void OnModelCreating(ModelBuilder builder) {

        builder.Entity<MapEntity>().HasKey(me => new {
            me.EntityId,
            me.SavedGameId
        });
        
        builder.Entity<MapEntity>()
            .HasOne(me => me.SavedGame)
            .WithMany(s => s.MapEntities)
            .HasForeignKey(me => me.SavedGameId);

        builder.Entity<MapEntity>()
            .HasOne(me => me.AEntity)
            .WithMany(e => e.MapEntities)
            .HasForeignKey(me => me.EntityId);

        builder.Entity<Defender>()
            .HasDiscriminator<string>("ENTITY_TYPE")
            .HasValue<Archer>("ARCHER")
            .HasValue<LongbowArcher>("LONGBOW_ARCHER");

        builder.Entity<Attacker>()
            .HasDiscriminator<string>("ENTITY_TYPE")
            .HasValue<Oni>("ONI");


        builder.Entity<SavedGame>()
            .HasIndex(a => a.Name)
            .IsUnique();

        builder.Entity<AField>()
            .HasOne(f => f.Map)
            .WithMany(m => m.Fields)
            .HasForeignKey(f => f.MapId);

        builder.Entity<AField>().HasKey(f => new {
            f.X, 
            f.Y
        });
        
        builder.Entity<AField>()
            .HasDiscriminator<string>("FIELD_TYPE")
            .HasValue<DownLeftTurn>("DOWN_LEFT_TURN")
            .HasValue<DownRightTurn>("DOWN_RIGHT_TURN")
            .HasValue<EmptyField>("EMPTY_FIELD")
            .HasValue<HorizontalStraight>("HORIZONTAL_STRAIGHT")
            .HasValue<UpLeftTurn>("UP_LEFT_TURN")
            .HasValue<UpRightTurn>("UP_RIGHT_TURN")
            .HasValue<VerticalStraight>("VERTICAL_STRAIGHT");

        
    }
}