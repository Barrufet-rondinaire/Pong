using Heirloom;
using Heirloom.Desktop;

namespace Pong;

public class Camp
{
    private const int LlargadaPala = 100;
    private const int AmpladaPala = 15;
    private const int VelocitatPala = 10;
    private const int MidaPilota = 10;
    private const int MitjaPilota = MidaPilota / 2;
    
    private readonly Window _finestra;
    private readonly List<Pala> _pales = [];
    private Pilota _pilota = null!;
    private Marcador _marcador = null!;

    private readonly Porteria[] _porteries = new Porteria[2];

    // private Dictionary<string, Image> _imatges = new();

    public Camp(Window finestra)
    {
        _finestra = finestra;
    }

    public void Carrega()
    {
        // Carregar imatges
        // _imatges["pilota"] = new Image("/imatges/pilota");
        
        // Crear objectes
        var posicioPorteria1 = new Rectangle(0, 0, 10, _finestra.Height);
        _porteries[0] = new Porteria(posicioPorteria1);
        var posicioPorteria2 = new Rectangle(_finestra.Width - 10, 0, 10, _finestra.Height);
        _porteries[1] = new Porteria(posicioPorteria2);
        
        var posicioPala1 = new Rectangle(26, (_finestra.Height-LlargadaPala)/2, AmpladaPala, LlargadaPala);
        _pales.Add(new Pala(posicioPala1, VelocitatPala));
        var posicioPala2 = new Rectangle(_finestra.Width-39, (_finestra.Height-LlargadaPala)/2, AmpladaPala, LlargadaPala);
        _pales.Add(new Pala(posicioPala2, VelocitatPala));

        var posicioPilota = new Rectangle(
            _finestra.Width / 2 - MitjaPilota,
            _finestra.Height / 2 - MitjaPilota,
            MidaPilota,
            MidaPilota);
        _pilota = new Pilota(posicioPilota, new Vector(1,0), 10 );
        
        _marcador = new Marcador(new Vector(_finestra.Width/2,10));
        
    }

    public void Juga(GraphicsContext gfx)
    {
        Mou();
        Interaccio();
        Pinta(gfx);
    }

    private void Interaccio()
    {
        // Mirar si la pilota ha tocat ...
        for (var index = 0; index < _porteries.Length; index++)
        {
            var porteria = _porteries[index];
            if (_pilota.Posicio.Overlaps(porteria.Posicio))
            {
                // gol
                _marcador.Gol((index+1)%2);

                var novaDireccio = new Vector(-1, 0);
                if (index == 1)
                {
                    novaDireccio = new Vector(1, 0);
                }
                _pilota.TornaAlCentre(novaDireccio);
                return;
            }
        }

        foreach (var pala in _pales)
        {
            if (_pilota.Posicio.Overlaps(pala.Posicio))
            {
                _pilota.Rebota(pala.Posicio);
                return;
            }
        }
        
        
    }

    private void Mou()
    {
        var rectanglePantalla = new Rectangle(0, 0, _finestra.Width, _finestra.Height);
        // Moure pales
        var movimentPala = new Vector[2];
        if (Input.CheckKey(Key.Up, ButtonState.Down))
        {
            movimentPala[0] = new Vector(0,-1);
        }
        if (Input.CheckKey(Key.Down, ButtonState.Down))
        {
            movimentPala[0] = new Vector(0,+1);
        }
        
        movimentPala[1] = AutoJuga(_pales[1]);

        for (var index = 0; index < _pales.Count; index++)
        {
            var pala = _pales[index];
            pala.Mou(movimentPala[index], rectanglePantalla);
        }

        // Moure Pilota
        _pilota.Mou(rectanglePantalla);
        // Mira si ha passat alguna cosa

    }

    private void Pinta(GraphicsContext gfx)
    {
        gfx.Clear(Color.Black);
        
        gfx.DrawLine(new Vector(_finestra.Width/2, 0),
            new Vector(_finestra.Width/2, _finestra.Height));

        foreach (var pala in _pales)
        {
            gfx.DrawRect(pala.Posicio);
        }
        
        gfx.DrawRect(_pilota.Posicio);
        
        gfx.DrawText(_marcador.Resultat(), 
            _marcador.Posicio,
            Font.Default,
            100,
            TextAlign.Center | TextAlign.Top);
    }

    private Vector AutoJuga(Pala pala)
    {
        if (_pilota.Posicio.Bottom < pala.Posicio.Y)
        {
            return new Vector(0,-1);
        }
        
        if (_pilota.Posicio.Y > pala.Posicio.Bottom)
        {
            return new Vector(0, +1);
        }
        
        return new Vector(0, 0);
    }
    
}