﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public static class UserStatic
    {
        public static int UserID { get; set; } = 1;
        public static bool isAdmin { get; set; }
        public static string NameSurname { get; set; }
        public static string ImagePath { get; set; }
    }
}
