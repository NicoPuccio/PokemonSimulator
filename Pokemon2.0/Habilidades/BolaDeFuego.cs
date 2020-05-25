using System;

namespace PokemonParcial1
{
	public class BolaDeFuego : Habilidad
	{
		
		private const double DAÑO_BOLA_DE_FUEGO = 10;

		public BolaDeFuego ()
		{
			this.Tipo = TipoElemento.eTipo.FUEGO;
			this.Nombre = "Bola de fuego";
		}



		public override void Activar (Pokemon atacante, Pokemon defensor)
		{
			double dañoFinal = DAÑO_BOLA_DE_FUEGO;

			dañoFinal += atacante.Fuerza;

			int critChance = rnd.Next (100);
			if (defensor.Tipo == TipoElemento.eTipo.PLANTA)
				dañoFinal *= 2;
			else if (defensor.Tipo == TipoElemento.eTipo.AGUA)
				dañoFinal *= 0.5;

			if (critChance < atacante.Suerte)
				dañoFinal *= 2;



			defensor.Vida -= dañoFinal;

		}

		public override string ToString ()
		{
			return "Bola de fuego que hace " + DAÑO_BOLA_DE_FUEGO + " de daño";
		}
	}
}

