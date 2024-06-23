using Collegium_of_Help.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.Models
{
    public class SourceModel
    {
        private Source _source;

        public SourceModel(Source source) => _source = source;

        public String Name
        {
            get => _source.Name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
