﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odawa.DAL;
using Odawa.BU.Entities;

namespace Odawa.BU
{
    static class ReservationManager
    {
        public static List<Reservation> GetAll()
        {
            return ReservationProvider.GetAll();
        }
    }
}