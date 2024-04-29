namespace Aplicacion;

public class Expediente
{
    private int id;
    private string caratula;
    private DateTime fechaCreacion;
    private DateTime fechaModificacion;
    private int idUsuarioModificacion;
    //private estadoExpediente estado; Clase ENUM aun no definida

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public string Caratula
    {
        get { return caratula; }
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