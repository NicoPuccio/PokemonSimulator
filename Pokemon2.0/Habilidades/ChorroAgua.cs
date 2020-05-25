using System;

namespace PokemonParcial1
{
	public class ChorroAgua : Habilidad
	{
		private const double DAÑO_CHORRO_AGUA = 10;

		public ChorroAgua ()
		{
			this.Tipo = TipoElemento.eTipo.AGUA;
			this.Nombre = "Chorro de agua";
		}


		public override void Activar (Pokemon atacante, Pokemon defensor)
		{
			double dañoFinal = DAÑO_CHORRO_AGUA;
			int critChance = rnd.Next (100);
            dañoFinal += atacante.Fuerza;

            if (defensor.Tipo == TipoElemento.eTipo.FUEGO)
				dañoFinal *= 2;

			else if (defensor.Tipo == TipoElemento.eTipo.PLANTA)
				dañoFinal *= 0.5; 

			if(critChance < atacante.Suerte)
				dañoFinal *= 2;

			
			defensor.Vida -= dañoFinal;
		}
	}
}

