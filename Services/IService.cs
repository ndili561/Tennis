﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IService
    {
        List<string> readfile(string path);
        void write(List<string> game,string path);
    }
}
