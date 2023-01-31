namespace ProductVarianter.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(
                this.colorize(this.getDateTimeNow(), "blue") +
                " " +
                message
            );
        }

        public void LogError(Exception exception)
        {
            Console.WriteLine(
                this.colorize(this.getDateTimeNow(), "blue") +
                " " +
                this.colorize(exception.Message, "red")
            );
        }

        public void LogEntity<T>(T entity)
        {
            if (entity != null)
            {
                Console.WriteLine(
                    this.colorize(this.getDateTimeNow(), "blue") +
                    " " +
                    entity.ToString()
                );
            }
        }

        private string getDateTimeNow()
        {
            return DateTime.Now.ToString("MMM dd HH:mm:ss");
        }

        private string colorize(string message, string color)
        {
            string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
            string RED = Console.IsOutputRedirected ? "" : "\x1b[91m";
            string GREEN = Console.IsOutputRedirected ? "" : "\x1b[92m";
            string YELLOW = Console.IsOutputRedirected ? "" : "\x1b[93m";
            string BLUE = Console.IsOutputRedirected ? "" : "\x1b[94m";

            switch (color)
            {
                case "red":
                    return RED + message + NORMAL;
                case "green":
                    return GREEN + message + NORMAL;
                case "yellow":
                    return YELLOW + message + NORMAL;
                case "blue":
                    return BLUE + message + NORMAL;
                default:
                    return message;
            }
        }
    }
}