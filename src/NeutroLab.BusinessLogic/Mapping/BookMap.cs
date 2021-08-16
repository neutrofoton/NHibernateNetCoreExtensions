using System;
using NeutroLab.BusinessLogic.Model;

namespace NeutroLab.BusinessLogic.Mapping
{
    public class BookMap : NHMap<Book, int>
    {
        public BookMap() : base(ConstantMap.Schema)
        {
            Property(x => x.Title);
        }
    }
}
