using MessagePipe;

public interface IGameSubscriber<TMessage> where TMessage : IMessage
{
    void Subscibe(ISubscriber<TMessage> subscriber);
    void Unsubscribe(ISubscriber<TMessage> subscriber);
}

public interface IMessage
{
    
}