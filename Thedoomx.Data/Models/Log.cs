﻿namespace Thedoomx.Data.Models
{
    using System;
    public class Log
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Level { get; set; }

        public string Logger { get; set; }

        public string Message { get; set; }

        public string Exception { get; set; }
    }
}
