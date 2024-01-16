using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student_Attendance_Record_SysteM.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student_Attendance_Record_SysteM.Models.Student> Student { get; set; } = default!;

        public DbSet<Student_Attendance_Record_SysteM.Models.User> User { get; set; } = default!;
    }
