using Heirloom;

namespace Pong;

public class Pala
{
    public Rectangle Posicio { get; private set; }
    private readonly int _velocitat;

    public Pala(Rectangle posicioInicial, int velocitatInicial) 
    {
        Posicio = posicioInicial;
        _velocitat = velocitatInicial;
    }
    public void Mou(Vector direccio, Rectangle midaPantalla)
    {
        if (direccio.X == 0 && direccio.Y == 0) return;
        
        var novaPosicio = Posicio;
        novaPosicio.Offset(direccio * _velocitat);
        if (midaPantalla.Contains(novaPosicio))
        {
            Posicio = novaPosicio;
        }
    }
   
}