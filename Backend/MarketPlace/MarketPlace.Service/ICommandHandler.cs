using System.Threading.Tasks;

namespace MarketPlace.Service
{
	public interface ICommandHandler<in TCommand>
    {
        Task Handle(TCommand command);
    }
}
