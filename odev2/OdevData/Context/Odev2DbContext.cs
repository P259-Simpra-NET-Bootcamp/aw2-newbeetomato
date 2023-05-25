using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdevData.Domain;



namespace OdevData.Context
{
    public class Odev2DbContext : DbContext
    {
        public Odev2DbContext(DbContextOptions<Odev2DbContext> options) : base(options)
        {

        }

        public DbSet<Staff> Staff { get; set; }



    }
}
