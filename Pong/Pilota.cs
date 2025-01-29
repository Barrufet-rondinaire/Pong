using Heirloom;

namespace Pong;

public class Pilota(Rectangle posicio, Vector direccio, int velocitat) : ObjectePantallaMou(posicio, velocitat)
{
    private readonly Rectangle _centre = posicio;
    private Vector _direccio = direccio;
    private readonly int _velocitatInicial = velocitat;

    public void Mou(Rectangle pantalla)
    {
        if (!base.Mou(_direccio, pantalla))
        {
            var novaPosicio = Posicio;
            novaPosicio.Offset(_direccio * Velocitat);
            if (novaPosicio.Top < pantalla.Top ||
                novaPosicio.Bottom > pantalla.Bottom)
            {
                _direccio.Y *= -1;
            }
            else
            {
                // TODO: Aquest l'haurem de treure
                _direccio.X *= -1;
            }
        }
    }

    public void Rebota(Rectangle palaPosicio)
    {
        Velocitat = _velocitatInicial;
        _direccio.X *= -1;
        
        var desplasament = 
            (Posicio.Y + Posicio.Height - palaPosicio.Y)/(palaPosicio.Height - Posicio.Height);
        var angle = 0.25f * Calc.Pi * (2 * desplasament -1);
        _direccio.Y = Calc.Sin(angle);
        
        // BuGFIX: En alguns casos la pilota es queda penjada perquè rebota i 
        //         surt de la pantalla. Això fa que no es mogui, torni a rebotar, 
        //         etc.
        //         La solució és fer que després de rebotar no xoqui amb la pala
        var novaPosicio = Posicio;
        novaPosicio.X = (Posicio.Center.X < palaPosicio.Center.X) ? palaPosicio.Left-Posicio.Width : palaPosicio.Right+1;
        Posicio = novaPosicio;
    }

    public void TornaAlCentre(Vector novaDireccio)
    {
        Posicio = _centre;
        _direccio = novaDireccio;
        Velocitat = _velocitatInicial/2;
    }
}