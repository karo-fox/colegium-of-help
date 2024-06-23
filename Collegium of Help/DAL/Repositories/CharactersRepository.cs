using Collegium_of_Help.Models;
using Collegium_of_Help.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.DAL.Repositories
{
    static class CharactersRepository
    {
        public static ObservableCollection<CharacterModel> GetAll()
        {
            ObservableCollection<CharacterModel> result = new();
            using (var db = new AppDBContext())
            {
                var characters = db.Characters.ToList();
                foreach (var character in characters)
                {
                    result.Add(new CharacterModel(character));
                }
            }
            return result;
        }

        public static void CreateOrUpdate(CharacterModel character)
        {
            using (var db = new AppDBContext())
            {
                int lastId = db.Characters.OrderBy(e => e.Id).Last().Id;
                var characterEntity = character.IsNew ? db.Add(new Character { Id = lastId + 1 }).Entity : db.Characters.Single(e => e.Id == character.Id);
                characterEntity.Name = character.Name;
                characterEntity.Race = character.Race.Id;
                characterEntity.Background = character.Background.Id;
                characterEntity.Class = character.Class.Id;
                characterEntity.Subclass = character.Subclass?.Id;
                characterEntity.Level = character.Level;
                characterEntity.Strength = character.Strength;
                characterEntity.Dexterity = character.Dexterity;
                characterEntity.Constitution = character.Constitution;
                characterEntity.Intelligence = character.Intelligence;
                characterEntity.Wisdom = character.Wisdom;
                characterEntity.Charisma = character.Charisma;
                characterEntity.CurrentHp = character.CurrentHp;
                characterEntity.TotalHp = character.TotalHp;
                characterEntity.Proficiencies = String.Join("; ", character.Proficiencies);
                characterEntity.Langauges = String.Join("; ", character.Langauges);
                characterEntity.Equipment = 0;
                db.SaveChanges();
            }
        }

        public static void Remove(CharacterModel character)
        {
            using (var db = new AppDBContext())
            {
                var characterEntity = db.Characters.Single(e => e.Id == character.Id);
                db.Remove(characterEntity);
                db.SaveChanges();
            }
        }
    }
}
