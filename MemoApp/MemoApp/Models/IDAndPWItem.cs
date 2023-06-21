using SQLite;
using System;

namespace MemoApp.Models
{
    public class IDAndPWItem
    {
        [PrimaryKey, AutoIncrement]
        public int Req { get; set; }
        public string ID { get; set; }
        public string Title { get; set; }
        public string Password { get; set; }

        [Indexed(Name = "idx_regdate", Order = 1, Unique = false)]
        public string RegDate { get; set; }
        public DateTime? RegDateTime { get; set; }
        
    }
}
