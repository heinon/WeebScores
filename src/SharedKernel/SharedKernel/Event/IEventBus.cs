using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Event;

public interface IEventBus
{
    Task PublishAsync<T>(T eventData, CancellationToken cancellationToken = default) where T : class;
    Task SendAsync<T>(T command, CancellationToken cancellationToken = default) where T : class;
}
