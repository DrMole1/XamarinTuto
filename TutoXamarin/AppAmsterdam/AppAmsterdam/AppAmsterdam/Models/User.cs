using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppAmsterdam.Models
{
    [Table("People")]

    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100), Unique]
        public string Name { get; set; }
    }
}
