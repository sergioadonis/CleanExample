using System;

namespace CleanExample.Common.Interfaces.Loggers
{
    public interface ILogger
    {
        /* Log a message object */
        void Debug(object message); // Solo para tiempo de desarrollo
        
        void Info(object message); // Para cualquier mensaje
        
        void Warn(object message); // Solo cuando hay un error controlado
        
        void Error(object message); // Cuando es un catch
        
        void Fatal(object message); // Cuando es un error muy grave que detiene la operacion
        
        
        /* Log a message object and exception */
        // void Debug(object message, Exception t);
        // void Info(object message, Exception t);
        // void Warn(object message, Exception t);
        // void Error(object message, Exception t);
        // void Fatal(object message, Exception t);
    }
}