namespace Aplicacion;

public class ExpedienteValidador
{
    public static void ValidarExpediente(Expediente expediente)
    {
        if (string.IsNullOrWhiteSpace(expediente.Caratula))
        {
            throw new ValidacionException("La carátula del expediente no puede estar vacía.");
        }

        if (expediente.IdUsuarioUltimaModificacion <= 0)
        {
            throw new ValidacionException("El ID de usuario de la última modificación del expediente no es válido.");
        }
    }
}