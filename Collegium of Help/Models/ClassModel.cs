using Collegium_of_Help.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.Models
{
    public class ClassModel
    {
        private Class _class;

        public ClassModel(Class @class) => _class = @class;

        public string Name
        {
            get => _class.Name;
            set => _class.Name = value;
        }
    }

}
