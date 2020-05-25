using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonParcial1
{
    class LatigoCepa : Habilidad
    {
        private const double DAÑO_LATIGO_CEPA = 10;
        public LatigoCepa()
        {
			this.Tipo = TipoElemento.eTipo.PLANTA;
			this.Nombre = "Latigo Cepa";
        }


        public override void Activar(Pokemon atacante, Pokemon defensor)
        {
            double dañoFinal = DAÑO_LATIGO_CEPA;
            int critChance = rnd.Next(100);
            dañoFinal += atacante.Fuerza;

            if (defensor.Tipo == TipoElemento.eTipo.AGUA)
                dañoFinal *= 2;

			else if (defensor.Tipo == TipoElemento.eTipo.FUEGO)
                dañoFinal *= 0.5;

            if (critChance < atacante.Suerte)
                dañoFinal *= 2;


            defensor.Vida -= dañoFinal;
        }
    }
}
