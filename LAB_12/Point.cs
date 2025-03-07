﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_12
{
    public class Point<T>
    {
        public T? Data { get; set; }
        public Point<T>? Next { get; set; }
        public Point<T>? Pred { get; set; }
        public Point()
        {
            this.Data = default(T);
            this.Pred = null;
            this.Next = null;
        }
        public Point(T data)
        {
            this.Data = data;
            this.Pred = null;
            this.Next = null;
        }
        public override string? ToString()
        {
            return Data is null ? "" : Data.ToString();
        }
        public override int GetHashCode()
        {
            return Data is null?0:Data.GetHashCode();
        }
    }
}
