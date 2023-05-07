using System;

namespace _20230408_AsyncProgramming_CRUD.Models.Entities.Abstract
{
    public enum Status { Active = 1, Modified, Passive }

    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
        //private DateTime _createDate = DateTime.Now;
        //public DateTime CreateDate
        //{
        //	get { return _createDate; }
        //	set { _createDate = value; }
        //}

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public Status Status { get; set; } = Status.Active;
    }
}