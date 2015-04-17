﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odawa.DAL;
using Odawa.BU.Entities;

namespace Odawa.BU
{
    static class TypeCuisineManager
    {
        public static List<TypeCuisine> GetAll()
        {
            return TypeCuisineProvider.GetTypeCuisine();
        }

        public static List<TypeCuisine> GetOne(int id)
        {
            return TypeCuisineProvider.GetTypeCuisine(id);
        }

        public static bool Create(TypeCuisine t)
        {
            if (t.type == null) return false;
            t.type = t.type.ToUpper();
            if (GetAll().Exists(x => x.type == t.type)) return false;
            TypeCuisineProvider.Create(t);
            return true;
        }
    }
}
