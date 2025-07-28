using MessagePipe;

public interface IGamePublisher
{
    void Publish(IPublisher<object> publisher);
}

public class GameMessagePublisher : IGamePublisher
{
    public void Publish(IPublisher<object> publisher)
    {
        throw new System.NotImplementedException();
    }
}