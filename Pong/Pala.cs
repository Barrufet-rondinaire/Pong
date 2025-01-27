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
    public void Mou(int direccio, Rectangle midaPantalla)
    {
        if (direccio == 0) return;
        
        var novaPosicio = Posicio;
        novaPosicio.Y += direccio * velocitat;
        if (midaPantalla.Contains(novaPosicio))
        {
            Posicio = novaPosicio;
        }
    }
   
}