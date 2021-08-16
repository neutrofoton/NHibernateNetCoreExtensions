using System;
using System.IO;
using System.Reflection;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.Attributes;
using NHibernate.Mapping.ByCode;

namespace NeutroLab.Extensions.NHibernate
{
    public static class NHibernateConfigurationExtensions
    {
        public static Configuration AddMappingByAttributes(this Configuration configuration, Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            using (MemoryStream stream = new MemoryStream())
            {
                HbmSerializer.Default.HbmNamespace = assembly.FullName;
                HbmSerializer.Default.HbmAssembly = assembly.FullName;
                HbmSerializer.Default.Serialize(stream, assembly);

                stream.Position = 0;

                return configuration.AddInputStream(stream);
            }
        }

        public static Configuration AddMappingByCode(this Configuration configuration, Assembly assembly)
        {
            var exportedTypes = assembly.GetExportedTypes();

            var mapper = new ModelMapper();
            mapper.AddMappings(assembly.GetExportedTypes());

            mapper.BeforeMapClass += (mi, t, map) => map.Table(t.Name.ToLower());
            mapper.BeforeMapJoinedSubclass += (mi, t, map) => map.Table(t.Name.ToLower());
            mapper.BeforeMapUnionSubclass += (mi, t, map) => map.Table(t.Name.ToLower());

            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            configuration.AddMapping(domainMapping);

            return configuration;
        }

        public static Configuration AddMappingMapByHbm(this Configuration configuration, Assembly assembly)
        {
            configuration.AddAssembly(assembly);
            return configuration;
        }

        public static Configuration AddMappingByHbm(this Configuration configuration, string[] xmlMappingFiles)
        {
            if (xmlMappingFiles != null && xmlMappingFiles.Length > 0)
            {
                foreach (var xmlMap in xmlMappingFiles)
                {
                    configuration.AddXmlFile(xmlMap);
                }
            }

            return configuration;
        }
    }
}
