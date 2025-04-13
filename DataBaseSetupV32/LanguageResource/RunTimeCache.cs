using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Caching; 

namespace LanguageResource
{
    public class RunTimeCache
    {
        public static FIFOCache<string, byte[]> FIFOCache()
        {
            try
            {
                int capacity = 2048;
                int evictCount = 512;
                bool cacheDebug = false; //console debug
                FIFOCache<string, byte[]> cache = new FIFOCache<string, byte[]>(capacity, evictCount, cacheDebug);
                return cache;
            }
            catch
            {
                return null;
            }
        }
        public static byte[] InitByteArray(int count, byte val)
        {
            byte[] ret = new byte[count];
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = val;
            }
            return ret;
        } 
        public static byte[] ConvertToByte(Object obj)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, obj);
                Byte[] ByteData = memoryStream.ToArray();
                return ByteData;
            }
        }
    }
}
