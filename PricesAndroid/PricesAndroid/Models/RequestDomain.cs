﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PricesAndroid.Models
{
    public class RequestDomain
    {
        public int Id { get; set; }

        public int RequestNumber { get; set; }

        public StatusEnum Status { get; set; }

        public string DepartureCity { get; set; }

        public string ArrivalCity { get; set; }

        public int ContainerSize { get; set; }

        public int CargoWeight { get; set; }

        public decimal Price { get; set; }

        public string DepartureDate { get; set; }

        public string RequestCreateDate { get; set; }

        public string Comment { get; set; }

        public int ClientId { get; set; }
    }
}
