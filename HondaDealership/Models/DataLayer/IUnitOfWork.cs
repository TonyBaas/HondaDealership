using System.Threading.Tasks;
using System;

namespace HondaDealership.Models.DataLayer
{
    public interface IUnitOfWork
    {
        Repository<Honda> Hondas { get; }
        void Save();
    }
}
