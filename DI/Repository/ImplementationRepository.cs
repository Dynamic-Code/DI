using DI.IRepository;

namespace DI.Repository
{
    public class ImplementationRepository : ISingleton,IScoped,ITransient
    {
        Guid _id;
        public ImplementationRepository()
        {
            _id = Guid.NewGuid();
        }
        public Guid GetGuid()
        {
            return _id;
        }
    }
}
