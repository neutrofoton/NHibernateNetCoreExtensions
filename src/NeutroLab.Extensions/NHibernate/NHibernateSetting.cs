using System;
using System.Collections.Generic;

namespace NeutroLab.Extensions.NHibernate
{
    public class NHibernateSetting
    {
        public const string SECTION_NAME = "NHibernate";

        public string ConnectionStringName { get; set; }

        public IDictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
    }
}
