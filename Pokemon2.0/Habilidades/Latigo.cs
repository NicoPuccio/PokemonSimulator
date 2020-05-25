using System;

namespace PokemonParcial1
{
	public class Latigo : Habilidad
	{
		private const double REDUCCION_DEFENSA_LATIGO = 5;

		public Latigo ()
		{
			this.Nombre = "Latigo";
		}
		public override void Activar (Pokemon atacante, Pokemon defensor)
		{
			int critDefense = rnd.Next (100);
			double defensaFinal = REDUCCION_DEFENSA_LATIGO;
			if (critDefense < atacante.Suerte)
				defensaFinal *= 2;
			defensor.Armadura -= defensaFinal;
		}

	}
}

