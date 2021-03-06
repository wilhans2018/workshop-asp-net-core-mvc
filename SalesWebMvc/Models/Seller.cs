﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email{ get; set; }
        public DateTime BirtyDate { get; set; }
        public double Basesalary { get; set; }
        public Departament Departament { get; set; }
        public int DepartamentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() {
        }

        public Seller(int id, string name, string email, DateTime birtyDate, double basesalary, Departament departament)
        {
            Id = id;
            Name = name;
            Email = email;
            BirtyDate = birtyDate;
            Basesalary = basesalary;
            this.Departament = departament;
        }

        public void AddSales(SalesRecord sr) {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr) {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final) {

            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
