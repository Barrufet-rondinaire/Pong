using Heirloom;

namespace Pong;

public class ObjectePantalla
{
    public Rectangle Posicio { get; protected set; }

    public ObjectePantalla(Rectangle posicio)
    {
        Posicio = posicio;
    }
}