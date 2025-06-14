﻿using System;

namespace Caching
{
    internal class DataNode<T>
    {
        public T Data { get; set; }
        public DateTime Added { get; set; }
        public DateTime LastUsed { get; set; }

        public DataNode()
        {
            DateTime ts = DateTime.Now;
            Added = ts;
            LastUsed = ts;
        }

        public DataNode(T val)
        {
            DateTime ts = DateTime.Now;
            Added = ts;
            LastUsed = ts;
            Data = val;
        }
    }
}
