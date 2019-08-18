using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntityCoreCrud.Models
{
    public class UserDbContext:DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public UserDbContext(DbContextOptions<UserDbContext> options)
            :base(options)
        { }
    }
}
