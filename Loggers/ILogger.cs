namespace ProductVarianter.Loggers
{
    public interface ILogger
    {
        void Log(string message);
        void LogError(Exception exception);
        void LogEntity<T>(T entity);
    }
}