using SQLite;
using System;

namespace MemoApp.Models
{
    public class MemoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }

        [Indexed(Name = "idx_regdate", Order = 1, Unique = false)]
        public string RegDate { get; set; }
        public DateTime? RegDateTime { get; set; }
        
        //public bool Done { get; set; }
    }
}
