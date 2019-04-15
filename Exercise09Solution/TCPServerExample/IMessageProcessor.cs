namespace TCPServerExample
{
    public interface IMessageProcessor
    {
        void Process(string message);
    }
}