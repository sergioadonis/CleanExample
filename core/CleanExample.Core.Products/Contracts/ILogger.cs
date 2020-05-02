namespace CleanExample.Core.Products.Contracts
{
    public interface ILogger
    {
        /* Log a message and data object */
        void Log(string message, object data = null, LogType type = LogType.Info);
    }

    public enum LogType
    {
        Debug, // Solo para tiempo de desarrollo
        Info, // Para cualquier mensaje
        Warn, // Solo cuando hay un error controlado
        Error, // Cuando es un catch
        Fatal // Cuando es un error muy grave que detiene la operacion
    }
}