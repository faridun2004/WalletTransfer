using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenderWallet.Application.Common.Interfaces
{
    public interface IEventBusPublisher
    {
        Task PublishAsync<T>(T _event) where T : class;
    }
}
