namespace Aplicacion;
//HOLA MUNDO
/*
El Id del trámite, identificador numérico único entre todos los trámites gestionados por el
sistema
El Id del expediente al que pertenece, propiedad ExpedienteId mencionada previamente
La etiqueta que identifica el tipo de trámite
El contenido específico del trámite, texto ingresado por el usuario
La fecha y hora de creación del trámite
La fecha y hora de la última modificación del trámite
El usuario que realizó la última modificación, identificado por su Id de usuario.

Los valores posibles para establecer la etiqueta de un trámite son los siguientes:

Escrito presentado
Pase a estudio
Despacho
Resolución
Notificación
Pase al Archivo
*/
public class Tramite
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
    public string contenido {get; private set; }   
    public DateTime fecha_hora_creacion{get;} = DateTime.Now;
    //Opte por que sea una propiedad de unica lectura ya 
    //que toma la hora del momento en que se crea una instancia Tramite
    public DateTime fecha_hora_ultimaModificacion{get; private set; };
    public int idUsuario{get; private set; };
    public EstadoTramite estadoTramite{ get; private set;}
    /*Todas son propiedades de Lectura Publica, mas su modificacion de los campos 
    sera privada por instancia Esto para llevar una correcta actualizacion */
    public Tramite()
    {
        id  = s_id;
        s_id++;
        //Constructor Vacio;
    }
    //IMPLEMENTAR VALIDADORES TRY CATCH PATOOO, Constructor Completo.
    public Tramite (int idExpediente, string contenido, int idUsuario, EstadoTramite estadoTramite)
    {
        id  = s_id;
        s_id++;
        ExpedienteId = idExpediente;
        ActualizarContenido(contenido, idUsuario); 
        this.idUsuario = idUsuario;
        this.estadoTramite = estadoTramite;
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
            throw new ContenidoException("Error : Contenido no valido", "El campo Esta Incompleto");
            }
            this.contenido = contenido;
            UltimaModificacion(idUsuario);
        }
        catch (ContenidoException e)
        {
            Console.WriteLine($"{e.message}, {e.type}");
        }
    }
    //Metodo para Actualizacion del estado Del tramite
    public void ActualizarEstado(EstadoTramite estadoTramite, int idUsuario)
    {
        this.estadoTramite = estadoTramite;
        UltimaModificacion(idUsuario);
    }
}