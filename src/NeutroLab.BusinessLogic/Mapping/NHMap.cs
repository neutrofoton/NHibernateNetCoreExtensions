using System;
using NeutroLab.BusinessLogic.Model;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NeutroLab.BusinessLogic.Mapping
{
    public abstract class NHMap<T> : ClassMapping<T> where T : class
    {
        public NHMap(string schema)
        {
            Schema(schema);
            Lazy(true);
        }
    }

    public abstract class NHMap<T, TId> : NHMap<T> where T : Entity<TId>
    {
        public NHMap(string schema, string tableName = null)
            : base(schema)
        {
            if (string.IsNullOrEmpty(tableName) || string.IsNullOrWhiteSpace(tableName))
                tableName = typeof(T).Name;

            Table(tableName);
            Id(x => x.Id,
               map => map.Generator(Generators.Native, g => g.Params(new
               {
                   sequence = tableName + "_id_seq",
                   schema = schema,
                   //catalog = null,
                   //parameters = null, // driver-specific DDL string to be appended to create command
               })));

        }
    }
}
