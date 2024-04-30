//PATO METETE A LA CONSOLA Y FIJATE PORQUE PORONGOL NO FUNCIONA, PROBE 124 COSAS DISTINTAS
// Mira Tenes que poner desde consola una referencia entre la aplicacion Consola y Aplicacion
// dotnet add Consola reference Aplicacion


using Aplicacion;
class Program
    {
        static void Main(string[] args)
        {
            // Crear un expediente
            var expediente = new Expediente("Carátula de ejemplo", EstadoExpediente.RecienIniciado, 1);
            Console.WriteLine($"Expediente creado con ID: {expediente.Id}");

            // Crear un trámite
            var tramite = new Tramite(expediente.Id, "Contenido de trámite de ejemplo", 1, EstadoTramite.Escrito_Presentado);
            Console.WriteLine($"Trámite creado con ID: {tramite.id}");

            // Actualizar el contenido del trámite
            tramite.ActualizarContenido("Nuevo contenido de trámite", 2);
            Console.WriteLine($"Contenido del trámite actualizado: {tramite.contenido}");

            // Validar el expediente
            try
            {
                ExpedienteValidador.ValidarExpediente(expediente);
                Console.WriteLine("El expediente es válido.");
            }
            catch (ValidacionException ex)
            {
                Console.WriteLine($"Error al validar expediente: {ex.Message}");
            }

            // Validar el trámite
            try
            {
                var tramiteValidador = new TramiteValidador();
                tramiteValidador.ValidarTramite(tramite);
                Console.WriteLine("El trámite es válido.");
            }
            catch (ValidacionException ex)
            {
                Console.WriteLine($"Error al validar trámite: {ex.Message}");
            }

            // Probar el servicio de autorización provisional
            var servicioAutorizacion = new ServicioAutorizacionProvisorio();
            var tienePermiso = servicioAutorizacion.PoseeElPermiso(1, Permiso.AdministrarExpedientes);
            Console.WriteLine($"¿El usuario 1 tiene permiso para administrar expedientes?: {tienePermiso}");
        }
    }