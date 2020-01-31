namespace CleanExample.Common.UseCases.Models
{
    public enum StatusCode
    {
        Default = 0,
        Success = 1, // Resultado exitoso
        PartialSuccess = 2, // Resultado exitoso pero parcial

        BusinessRulesError = 400, // Errores por reglas del negocio

        UnknownResult = 500, // Resultado desconocido
        DatabaseError = 501 // Errores por infraestructura (base de datos, red, sistema de archivos, colas)
    }
}