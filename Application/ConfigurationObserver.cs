using Application.Configuration;
using Domain.Configuration;

namespace Application
{
    public class ConfigurationObserver : IObserver<HandlersConfiguration>
    {
        private readonly HandlersConfigurationBuilder _builder;

        public ConfigurationObserver(HandlersConfigurationBuilder builder)
        {
            _builder = builder;
        }
        public void OnCompleted()
            => new NotImplementedException();
     
        public void OnError(Exception error)
            =>  throw new NotImplementedException();

        public void OnNext(HandlersConfiguration value)
        {
            _builder.BuildNotificationChain(value);
        }
    }
}
