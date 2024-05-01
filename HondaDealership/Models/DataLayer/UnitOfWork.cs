using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HondaDealership.Models.DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context { get; set; }
        private Repository<Honda> hondaData { get; set; }
        public Repository<Honda> Hondas
        {
            get
            {
                if (hondaData == null)
                {
                    hondaData = new Repository<Honda>(context);
                }
                return hondaData;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }


        public UnitOfWork(ApplicationDbContext ctx)
        {
            this.context = ctx;
        }
    }
}
