using Collegium_of_Help.Models.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.Models
{
    public class SubclassModel
    {
        private Subclass _subclass;

        public SubclassModel(Subclass subclass) => _subclass = subclass;

        public string Name
        {
            get => _subclass.Name;
        }
    }
}
