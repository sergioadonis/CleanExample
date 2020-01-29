namespace CleanExample.Common.UseCases.Models
{
    public enum StatusCode
    {
        Success = 0, // Resultado exitoso
        PartialSuccess = 1, // Resultado exitoso pero parcial

        BusinessRulesError = 400, // Errores por reglas del negocio

        UnknownError = 500,
        DatabaseError = 501 // Errores por infraestructura (base de datos, red, sistema de archivos, colas)
    }
}