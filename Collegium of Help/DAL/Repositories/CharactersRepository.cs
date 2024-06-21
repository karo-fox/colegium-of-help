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
    }
}
