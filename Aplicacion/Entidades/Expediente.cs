namespace Aplicacion;

public class Expediente
{
    private static int s_id = 1;
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
        set {   try
                {
                    if(string.IsNullOrWhiteSpace(value))
                    {
                        throw new ValidacionException("Error : Contenido no valido", "El campo Esta Incompleto");
                    }
                    this.contenido = value;
                }
                catch (ValidacionException e)
                {
                    Console.WriteLine($"{e.message}, {e.type}");
                }
             }
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
        id = s_id;
        s_id++;
        fechaCreacion = DateTime.Now;
        fechaModificacion = DateTime.Now;
    }

    public Expediente(string Caratula, EstadoExpediente Estado, int Usuario)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Caratula))
            {
                throw new ValidacionException("La carátula del expediente no puede estar vacía.");
            }
            id = s_id;
            s_id++;
            fechaCreacion = DateTime.Now;
            fechaModificacion = DateTime.Now;
            this.caratula = Caratula;
            this.estado = Estado;
            idUsuarioModificacion = Usuario;
        }
        catch(ValidacionException e)
        {
            Console.WriteLine($"{e.message}, {e.type}");
        }
    }

    private void ActualizarFechaModificacion(int idUsuario)
    {
        fechaModificacion = DateTime.now;
        idUsuarioModificacion = idUsuario;
    } 

    public void ActualizarContenido(string contenido, int idUsuario)
    {
        try
        {
            if(string.IsNullOrWhiteSpace(contenido))
            {
                throw new ValidacionException("Error : Contenido no valido", "El campo Esta Incompleto");
            }
            this.contenido = contenido;
            ActualizarFechaModificacion(idUsuario);
        }
        catch (ValidacionException e)
        {
            Console.WriteLine($"{e.message}, {e.type}");
        }
    }
}