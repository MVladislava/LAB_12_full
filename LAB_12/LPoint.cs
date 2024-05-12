using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_12
{
    public class LPoint<T>
    {
        public T? Data { get; set; }
        public LPoint<T>? Next { get; set; }
        public LPoint<T>? Pred { get; set; }
        public LPoint()
        {
            this.Data = default;
            this.Pred = null;
            this.Next = null;
        }
        public LPoint(T data)
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
            return Data is null ? 0 : Data.GetHashCode();
        }
    }
}
