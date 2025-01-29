using Heirloom;

namespace Pong;

public class Pilota
{
    public Rectangle Posicio { get; private set; }
    private readonly Rectangle _centre;
    private Vector _direccio;
    private int _velocitat;
    private readonly int _velocitatInicial;

    public Pilota(Rectangle posicio, Vector direccio, int velocitat)
    {
        Posicio = posicio;
        _centre = posicio;
        _direccio = direccio;
        _velocitat = velocitat;
        _velocitatInicial = velocitat;
    }

    public void Mou(Rectangle pantalla)
    {
        var novaPosicio = Posicio;

        // novaPosicio.X += _direccio.X * _velocitat;
        // novaPosicio.Y += _direccio.Y * _velocitat;
        novaPosicio.Offset(_direccio * _velocitat);
        if (pantalla.Contains(novaPosicio))
        {
            Posicio = novaPosicio;
        }
        else
        {
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
        _velocitat = _velocitatInicial;
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
        novaPosicio.X = (Posicio.Center.X < palaPosicio.Center.X) ? palaPosicio.Left-1 : palaPosicio.Right+1;
        Posicio = novaPosicio;
    }

    public void TornaAlCentre(Vector novaDireccio)
    {
        Posicio = _centre;
        _direccio = novaDireccio;
        _velocitat = _velocitatInicial/2;
    }
}