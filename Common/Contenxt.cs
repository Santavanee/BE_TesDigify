using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Contenxt : DbContext
    {
        public Contenxt()
        {
        }

        public Contenxt(DbContextOptions options) : base(options)
        {

        }


    }
}
