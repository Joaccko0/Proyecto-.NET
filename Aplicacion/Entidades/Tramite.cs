namespace Aplicacion;
public class Tramite:IDisposable
{
    private static int s_id = 0;
    //LLevo un conteo estatico en el constructor para generar ids unicos de forma ascendente
    public int id {get; private set; } 
    
    private int _idExpediente;
    //Delego Responsabilidad a la propiedad ExpedienteId.
    public int ExpedienteId
    {
        get
        {
            return _idExpediente;
        }
        set{
            _idExpediente = (int)value;
        }
    }
    public string? contenido {get; private set; }   
    public DateTime fecha_hora_creacion{get;} = DateTime.Now;
    //Opte por que sea una propiedad de unica lectura ya 
    //que toma la hora del momento en que se crea una instancia Tramite
    public DateTime fecha_hora_ultimaModificacion{get; private set; }
    public int idUsuario{get; private set; }
    public EstadoTramite estadoTramite{ get; private set;}
    /*Todas son propiedades de Lectura Publica, mas su modificacion de los campos 
    sera privada por instancia Esto para llevar una correcta actualizacion */
    public Tramite()
    {
        id  = s_id;
        s_id++;
        contenido = "";
        //Constructor Vacio;
    }
    //IMPLEMENTAR VALIDADORES TRY CATCH PATOOO, Constructor Completo.
    public Tramite (int idExpediente, string contenido, int idUsuario, EstadoTramite estadoTramite)
    {
        try
        {
        id  = s_id;
        s_id++;
        ExpedienteId = idExpediente;
        ActualizarContenido(contenido, idUsuario); 
        this.idUsuario = idUsuario;
        this.estadoTramite = estadoTramite;
        }
        catch(ValidacionException e)
        {
            
            Console.WriteLine($"{e.Message}");
        }

        //Desconosco si debemos llamar a un destructor si hay cagada.
    }
    //Metodo Privado Para Actualizacion UltimaModificacion
    private void UltimaModificacion(int idUsuario)
    {
        this.idUsuario = idUsuario;
        this.fecha_hora_ultimaModificacion = DateTime.Now; 
    }
    //MetodoParaActualizacion del contenido;
    public void ActualizarContenido(string contenido, int idUsuario)
    {   
        try
        {
            if(string.IsNullOrWhiteSpace(contenido))
            {
            throw new ValidacionException("Error : Contenido El campo no puede estar vacio");
            }
            this.contenido = contenido;
            UltimaModificacion(idUsuario);
        }
        catch (ValidacionException e)
        {
            Console.WriteLine($"{e.Message}");
        }
    }
    //Metodo para Actualizacion del estado Del tramite
    public void ActualizarEstado(EstadoTramite estadoTramite, int idUsuario)
    {
        this.estadoTramite = estadoTramite;
        UltimaModificacion(idUsuario);
    }


    public void Dispose()
    {
        throw new NotImplementedException();
    }
    /*
    Usaremos mas Adelante
    ~Tramite()
    {
        Console.WriteLine("Unussed");
        using(Tramite tramite = this)
        {
            tramite.Dispose();
        }
    }
    */
}