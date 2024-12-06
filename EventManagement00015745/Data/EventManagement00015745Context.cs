using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EventManagement00015745.Entities;

    public class EventManagement00015745Context : DbContext
    {
        public EventManagement00015745Context (DbContextOptions<EventManagement00015745Context> options)
            : base(options)
        {
        }

        public DbSet<EventManagement00015745.Entities.Event> Event { get; set; } = default!;
    }
