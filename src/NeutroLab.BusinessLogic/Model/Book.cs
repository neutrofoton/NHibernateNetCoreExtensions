using System;
namespace NeutroLab.BusinessLogic.Model
{
    public class Book : Entity<int>
    {
        public virtual string Title { get; set; }
    }
}
