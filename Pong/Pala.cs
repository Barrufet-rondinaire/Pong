using Heirloom;

namespace Pong;

public class Pala
{
    public Rectangle Posicio { get; private set; }
    private int velocitat;

    public Pala(Rectangle posicioInicial, int velocitatInicial) 
    {
        Posicio = posicioInicial;
        velocitat = velocitatInicial;
    }
    public void Mou(Vector direccio, Rectangle midaPantalla)
    {
        if (direccio.X == 0 && direccio.Y == 0) return;
        
        var novaPosicio = Posicio;
        novaPosicio.Offset(direccio * velocitat);
        if (midaPantalla.Contains(novaPosicio))
        {
            Posicio = novaPosicio;
        }
    }
   
}