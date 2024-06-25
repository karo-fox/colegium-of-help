using Collegium_of_Help.DAL;
using Collegium_of_Help.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Collegium_of_Help.WDiscarded
{
    public class DatabaseModel
    {
        public List<Source> Sources { get; set; }
        //private AppDBContext db = new AppDBContext();
        public DatabaseModel()
        {
            /*
            using (var db = new AppDBContext())
            {
                Sources = db.Sources.ToList();
            }
            */
            Sources = new List<Source>();
        }
    }
}
