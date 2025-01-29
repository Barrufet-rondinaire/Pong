using Heirloom;

namespace Pong;

public class ObjectePantallaMou: ObjectePantalla
{
    protected int Velocitat;
    
    public ObjectePantallaMou(Rectangle posicio, int velocitat) : base(posicio)
    {
        Velocitat = velocitat;
    }
    
    public bool Mou(Vector direccio, Rectangle midaPantalla)
    {
        if (direccio.X == 0 && direccio.Y == 0) return false;
        
        var novaPosicio = Posicio;
        novaPosicio.Offset(direccio * Velocitat);
        if (midaPantalla.Contains(novaPosicio))
        {
            Posicio = novaPosicio;
            return true;
        }
        return false;
    }
}