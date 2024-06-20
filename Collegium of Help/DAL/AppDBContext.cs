using System;
using System.Collections.Generic;
using System.Configuration;
using Collegium_of_Help.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Collegium_of_Help.DAL;

public partial class AppDBContext : DbContext
{
    private const string CONNECTION_STRING_NAME = "CollegiumOfHelpConnection";
    public AppDBContext()
    {
    }

    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Background> Backgrounds { get; set; }

    public virtual DbSet<BackgroundEquipment> BackgroundEquipments { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<CharacterEquipment> CharacterEquipments { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassClassTrait> ClassClassTraits { get; set; }

    public virtual DbSet<ClassEquipment> ClassEquipments { get; set; }

    public virtual DbSet<ClassSpell> ClassSpells { get; set; }

    public virtual DbSet<ClassTrait> ClassTraits { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<RacialTrait> RacialTraits { get; set; }

    public virtual DbSet<Source> Sources { get; set; }

    public virtual DbSet<Spell> Spells { get; set; }

    public virtual DbSet<Subclass> Subclasses { get; set; }

    public virtual DbSet<SubclassClassTrait> SubclassClassTraits { get; set; }

    public virtual DbSet<SubclassSpell> SubclassSpells { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySQL(ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME]?.ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Background>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("backgrounds");

            entity.HasIndex(e => e.SourceBook, "source_book");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Feature)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("feature");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.SkillProficiencies)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("skill_proficiencies");
            entity.Property(e => e.SourceBook).HasColumnName("source_book");

            entity.HasOne(d => d.SourceBookNavigation).WithMany(p => p.Backgrounds)
                .HasForeignKey(d => d.SourceBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("backgrounds_ibfk_1");
        });

        modelBuilder.Entity<BackgroundEquipment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("background_equipment");

            entity.HasIndex(e => e.BackgroundId, "background_id");

            entity.HasIndex(e => e.EquipmentId, "equipment_id");

            entity.Property(e => e.BackgroundId).HasColumnName("background_id");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");

            entity.HasOne(d => d.Background).WithMany()
                .HasForeignKey(d => d.BackgroundId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("background_equipment_ibfk_2");

            entity.HasOne(d => d.Equipment).WithMany()
                .HasForeignKey(d => d.EquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("background_equipment_ibfk_1");
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("characters");

            entity.HasIndex(e => e.Background, "background");

            entity.HasIndex(e => e.Class, "class");

            entity.HasIndex(e => e.Race, "race");

            entity.HasIndex(e => e.Subclass, "subclass");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Background).HasColumnName("background");
            entity.Property(e => e.Charisma).HasColumnName("charisma");
            entity.Property(e => e.Class).HasColumnName("class");
            entity.Property(e => e.Constitution).HasColumnName("constitution");
            entity.Property(e => e.CurrentHp).HasColumnName("current_HP");
            entity.Property(e => e.Dexterity).HasColumnName("dexterity");
            entity.Property(e => e.Equipment).HasColumnName("equipment");
            entity.Property(e => e.Intelligence).HasColumnName("intelligence");
            entity.Property(e => e.Langauges)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("langauges");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Proficiencies)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("proficiencies");
            entity.Property(e => e.Race).HasColumnName("race");
            entity.Property(e => e.SpellSlots)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("spell_slots");
            entity.Property(e => e.Strength).HasColumnName("strength");
            entity.Property(e => e.Subclass).HasColumnName("subclass");
            entity.Property(e => e.TotalHp).HasColumnName("total_HP");
            entity.Property(e => e.Wisdom).HasColumnName("wisdom");

            entity.HasOne(d => d.BackgroundNavigation).WithMany(p => p.Characters)
                .HasForeignKey(d => d.Background)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("characters_ibfk_2");

            entity.HasOne(d => d.ClassNavigation).WithMany(p => p.Characters)
                .HasForeignKey(d => d.Class)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("characters_ibfk_3");

            entity.HasOne(d => d.RaceNavigation).WithMany(p => p.Characters)
                .HasForeignKey(d => d.Race)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("characters_ibfk_1");

            entity.HasOne(d => d.SubclassNavigation).WithMany(p => p.Characters)
                .HasForeignKey(d => d.Subclass)
                .HasConstraintName("characters_ibfk_4");
        });

        modelBuilder.Entity<CharacterEquipment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("character_equipment");

            entity.HasIndex(e => e.CharacterId, "character_id");

            entity.HasIndex(e => e.EquipmentId, "equipment_id");

            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");

            entity.HasOne(d => d.Character).WithMany()
                .HasForeignKey(d => d.CharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("character_equipment_ibfk_2");

            entity.HasOne(d => d.Equipment).WithMany()
                .HasForeignKey(d => d.EquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("character_equipment_ibfk_1");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("classes");

            entity.HasIndex(e => e.SourceBook, "source_book");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HitDie).HasColumnName("hit_die");
            entity.Property(e => e.Money).HasColumnName("money");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Proficiencies)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("proficiencies");
            entity.Property(e => e.SavingThrowProficiencies)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("saving_throw_proficiencies");
            entity.Property(e => e.SkillProficiencies)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("skill_proficiencies");
            entity.Property(e => e.SkillsProficienciesNum).HasColumnName("skills_proficiencies_num");
            entity.Property(e => e.SourceBook).HasColumnName("source_book");

            entity.HasOne(d => d.SourceBookNavigation).WithMany(p => p.Classes)
                .HasForeignKey(d => d.SourceBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("classes_ibfk_1");
        });

        modelBuilder.Entity<ClassClassTrait>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("class_class_traits");

            entity.HasIndex(e => e.ClassId, "class_id");

            entity.HasIndex(e => e.ClassTraitId, "class_trait_id");

            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.ClassTraitId).HasColumnName("class_trait_id");

            entity.HasOne(d => d.Class).WithMany()
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("class_class_traits_ibfk_2");

            entity.HasOne(d => d.ClassTrait).WithMany()
                .HasForeignKey(d => d.ClassTraitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("class_class_traits_ibfk_1");
        });

        modelBuilder.Entity<ClassEquipment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("class_equipment");

            entity.HasIndex(e => e.ClassId, "class_id");

            entity.HasIndex(e => e.EquipmentId, "equipment_id");

            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.Slot).HasColumnName("slot");

            entity.HasOne(d => d.Class).WithMany()
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("class_equipment_ibfk_2");

            entity.HasOne(d => d.Equipment).WithMany()
                .HasForeignKey(d => d.EquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("class_equipment_ibfk_1");
        });

        modelBuilder.Entity<ClassSpell>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("class_spells");

            entity.HasIndex(e => e.ClassId, "class_id");

            entity.HasIndex(e => e.SpellId, "spell_id");

            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.SpellId).HasColumnName("spell_id");

            entity.HasOne(d => d.Class).WithMany()
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("class_spells_ibfk_2");

            entity.HasOne(d => d.Spell).WithMany()
                .HasForeignKey(d => d.SpellId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("class_spells_ibfk_1");
        });

        modelBuilder.Entity<ClassTrait>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("class_traits");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("description");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Optional).HasColumnName("optional");
            entity.Property(e => e.RefreshTime)
                .HasColumnType("enum('short rest','long rest','short or long rest','none','other')")
                .HasColumnName("refresh_time");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("equipment");

            entity.HasIndex(e => e.SourceBook, "source_book");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Alignment)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("alignment");
            entity.Property(e => e.Cost)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("cost");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("description");
            entity.Property(e => e.Magic).HasColumnName("magic");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Rarity)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("rarity");
            entity.Property(e => e.SourceBook).HasColumnName("source_book");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.SourceBookNavigation).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.SourceBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("equipment_ibfk_1");
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("races");

            entity.HasIndex(e => e.SourceBook, "source_book");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Langauges)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("langauges");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Size)
                .HasColumnType("enum('malutki','mały','średni','duży','wielki','ogromny')")
                .HasColumnName("size");
            entity.Property(e => e.SourceBook).HasColumnName("source_book");
            entity.Property(e => e.Speed).HasColumnName("speed");

            entity.HasOne(d => d.SourceBookNavigation).WithMany(p => p.Races)
                .HasForeignKey(d => d.SourceBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("races_ibfk_1");
        });

        modelBuilder.Entity<RacialTrait>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("racial_traits");

            entity.HasIndex(e => e.Race, "race");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Race).HasColumnName("race");
            entity.Property(e => e.RefreshTime)
                .HasColumnType("enum('short rest','long rest','short or long rest','none','other')")
                .HasColumnName("refresh_time");

            entity.HasOne(d => d.RaceNavigation).WithMany(p => p.RacialTraits)
                .HasForeignKey(d => d.Race)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("racial_traits_ibfk_1");
        });

        modelBuilder.Entity<Source>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sources");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("name");
        });

        modelBuilder.Entity<Spell>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("spells");

            entity.HasIndex(e => e.SourceBook, "source_book");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CastingTime)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("casting_time");
            entity.Property(e => e.Components)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("components");
            entity.Property(e => e.Concentration).HasColumnName("concentration");
            entity.Property(e => e.Duration)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("duration");
            entity.Property(e => e.Level)
                .HasColumnType("enum('sztuczka','1','2','3','4','5','6','7','8','9')")
                .HasColumnName("level");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.SavingThrow)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("saving_throw");
            entity.Property(e => e.School)
                .HasColumnType("enum('Iluzji','Nekromancji','Odpychania','Przywoływania','Przemiany','Uroków','Wieszczenia','Wywoływania','Inne')")
                .HasColumnName("school");
            entity.Property(e => e.SourceBook).HasColumnName("source_book");
            entity.Property(e => e.SpellRange)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("spell_range");

            entity.HasOne(d => d.SourceBookNavigation).WithMany(p => p.Spells)
                .HasForeignKey(d => d.SourceBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("spells_ibfk_1");
        });

        modelBuilder.Entity<Subclass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("subclasses");

            entity.HasIndex(e => e.Class, "class");

            entity.HasIndex(e => e.SourceBook, "source_book");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Class).HasColumnName("class");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.SourceBook).HasColumnName("source_book");

            entity.HasOne(d => d.ClassNavigation).WithMany(p => p.Subclasses)
                .HasForeignKey(d => d.Class)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("subclasses_ibfk_1");

            entity.HasOne(d => d.SourceBookNavigation).WithMany(p => p.Subclasses)
                .HasForeignKey(d => d.SourceBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("subclasses_ibfk_2");
        });

        modelBuilder.Entity<SubclassClassTrait>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("subclass_class_traits");

            entity.HasIndex(e => e.ClassTraitId, "class_trait_id");

            entity.HasIndex(e => e.SubclassId, "subclass_id");

            entity.Property(e => e.ClassTraitId).HasColumnName("class_trait_id");
            entity.Property(e => e.SubclassId).HasColumnName("subclass_id");

            entity.HasOne(d => d.ClassTrait).WithMany()
                .HasForeignKey(d => d.ClassTraitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("subclass_class_traits_ibfk_1");

            entity.HasOne(d => d.Subclass).WithMany()
                .HasForeignKey(d => d.SubclassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("subclass_class_traits_ibfk_2");
        });

        modelBuilder.Entity<SubclassSpell>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("subclass_spells");

            entity.HasIndex(e => e.SpellId, "spell_id");

            entity.HasIndex(e => e.SubclassId, "subclass_id");

            entity.Property(e => e.SpellId).HasColumnName("spell_id");
            entity.Property(e => e.SubclassId).HasColumnName("subclass_id");

            entity.HasOne(d => d.Spell).WithMany()
                .HasForeignKey(d => d.SpellId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("subclass_spells_ibfk_1");

            entity.HasOne(d => d.Subclass).WithMany()
                .HasForeignKey(d => d.SubclassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("subclass_spells_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
