﻿using DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public interface IPageService
    {
        Page GetPage();
        void SavePage(Page page);
    }
}