using SQLite;
using System;

namespace MemoApp.Models
{
    public class MemoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime? InsysDate { get; set; }
        
        //public bool Done { get; set; }
    }
}
