using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonParcial1
{
    class Terremoto : Habilidad
    {
        private const double DAÑO_TERREMOTO= 10;

        public Terremoto()
        {
			this.Tipo = TipoElemento.eTipo.TIERRA;
			this.Nombre = "Terremoto";
        }


        public override void Activar(Pokemon atacante, Pokemon defensor)
        {
            double dañoFinal = DAÑO_TERREMOTO;
            int critChance = rnd.Next(100);
            dañoFinal += atacante.Fuerza;

            if (defensor.Tipo == TipoElemento.eTipo.FUEGO)
                dañoFinal *= 2;

			else if (defensor.Tipo == TipoElemento.eTipo.AGUA)
                dañoFinal *= 0.5;

            if (critChance < atacante.Suerte)
                dañoFinal *= 2;


            defensor.Vida -= dañoFinal;
        }
    }
}
