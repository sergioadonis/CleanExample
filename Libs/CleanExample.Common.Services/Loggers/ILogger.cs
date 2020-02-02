namespace CleanExample.Common.Services.Loggers
{
    public interface ILogger
    {
        /* Log a message and data object */
        void Log(string message, object data = null, LogType type = LogType.INFO);
    }

    public enum LogType
    {
        DEBUG,      // Solo para tiempo de desarrollo
        INFO,       // Para cualquier mensaje
        WARN,       // Solo cuando hay un error controlado
        ERROR,      // Cuando es un catch
        FATAL       // Cuando es un error muy grave que detiene la operacion
    }

}