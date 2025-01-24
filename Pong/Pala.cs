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
    public void Mou(Rectangle midaPantalla)
    {
        
    }
   
}