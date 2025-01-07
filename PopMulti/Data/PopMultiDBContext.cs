using Microsoft.EntityFrameworkCore;
using PopMulti.Models;

namespace PopMulti.Data
{
    public class PopMultiDBContext : DbContext
    {
        public PopMultiDBContext() { }

        public PopMultiDBContext(DbContextOptions<PopMultiDBContext> options) : base(options) { }

        public DbSet<PopMulti.Models.PopModel.PopMultiModel> PopMultiDB {  get; set; }
    }
}
