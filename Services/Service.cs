using System;
using System.IO;
using System.Collections.Generic;

namespace Services
{
    public class Service : IService

    {
       
        public List<string> readfile(string path)
        {
            List<string> result = new List<string>();
            string line;
            using(StreamReader rd = new StreamReader(path))
            {
                while((line= rd.ReadLine()) != null)
                {
                    result.Add(line);
                }
            }
            return result;
            
        }
    }
}
