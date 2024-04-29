namespace Aplicacion;

public class Expediente
{
    private int id;
    private string caratula;
    private DateTime fechaCreacion;
    private DateTime fechaModificacion;
    private int idUsuarioModificacion;
    private estadoExpediente estado;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public string Caratula
    {
        get { return caratula; }
        //Revisar Usar el manejo de excepciones visto en la clase 6 para una correcta 
        set { caratula = (value != null) && (value != "") ? value : throw new ArgumentException("La carátula no puede estar vacía."); }
    }
    public DateTime FechaCreacion
    {
        get { return fechaCreacion;}
    }
    public DateTime FechaModificacion
    {
        get { return fechaModificacion;}
    }
    public int IdUsuarioModificacion
    {
        get { return idUsuarioModificacion;}
    }
    public EstadoExpediente Estado
    {
        get{ return estado; }
        set { estado = value; }
    }

    public Expediente()
    {
        fechaCreacion = DateTime.Now;
        fechaModificacion = DateTime.Now;
    }

    public void ActualizarFechaModificacion(int idUsuario)
    {
        fechaModificacion = DateTime.now;
        idUsuarioModificacion = idUsuario;
    } 
}