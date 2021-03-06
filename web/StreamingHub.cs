using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace streaming
{
    public class StreamingHub : Hub
    {

        public void SendStreamInit()
        {
            //开启客户端订阅
            Clients.All.InvokeAsync("streamStarted");
        }

        //被订阅的消息
        public IObservable<string> StartStreaming()
        {
            return Observable.Create(
                async (IObserver<string> observer) =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        observer.OnNext($"发送内容......{i}");
                        await Task.Delay(1000);
                    }
                });
        }
    }
}
