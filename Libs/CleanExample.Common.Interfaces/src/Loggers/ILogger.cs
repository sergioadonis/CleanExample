namespace CleanExample.Common.Interfaces.Loggers
{
    public interface ILogger
    {
        string Trace { get; set; }

        /* Log a message and data object */
        void Debug(string message, object data = null); // Solo para tiempo de desarrollo

        void Info(string message, object data = null); // Para cualquier mensaje

        void Warn(string message, object data = null); // Solo cuando hay un error controlado

        void Error(string message, object data = null); // Cuando es un catch

        void Fatal(string message, object data = null); // Cuando es un error muy grave que detiene la operacion
    }

    public enum LogType
    {
        DEBUG,
        INFO,
        WARN,
        ERROR,
        FATAL
    }

}