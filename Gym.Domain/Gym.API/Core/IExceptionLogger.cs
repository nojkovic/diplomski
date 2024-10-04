using Gym.Application;

namespace Gym.API.Core
{
    public interface IExceptionLogger
    {
        Guid Log(Exception ex, IApplicationActor actor);
    }
}
