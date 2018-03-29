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

        public void write(List<string> game, List<string> sets,List<string>setsplayed, string output)
        {
         
          
                using (StreamWriter tw = new StreamWriter(output))
                {
                   
                   //tw.Write(Environment.NewLine + string.Format("{0,-30} {1,-30}", list[0], list[0],true));
                  
             
                }

            
                    
        }
    }
}
