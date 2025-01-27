using Heirloom;

namespace Pong;

public class Pilota
{
    public Rectangle Posicio { get; private set; }
    private Rectangle Centre;
    private Vector _direccio;
    private int _velocitat;

    public Pilota(Rectangle posicio, Vector direccio, int velocitat)
    {
        Posicio = posicio;
        Centre = posicio;
        _direccio = direccio;
        _velocitat = velocitat;
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
}