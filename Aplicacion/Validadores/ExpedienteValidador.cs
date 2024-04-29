namespace Aplicacion;

public class ExpedienteValidador
{
    public static void ValidarExpediente(Expediente expediente)
    {
        if (string.IsNullOrWhiteSpace(expediente.Caratula))
        {
            throw new ArgumentException("La carátula del expediente no puede estar vacía.");
        }
    }
}
//Joacooooo Pasemos las excepciones a un archivo unico, como indica el trabajo /ValidacionException.cs