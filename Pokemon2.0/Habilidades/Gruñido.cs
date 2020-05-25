using System;

namespace PokemonParcial1
{
	public class Gruñido : Habilidad
	{
		private const double FUERZA_RUGIDO = 5;
		public Gruñido ()
		{
			this.Nombre = "Gruñido";
		}
		
		public override void Activar (Pokemon atacante, Pokemon defensor)
		{
			int critAttack = rnd.Next (100);
			double fuerzaFinal = FUERZA_RUGIDO;
			if (critAttack < atacante.Suerte)
				fuerzaFinal *= 2;

			atacante.Fuerza += fuerzaFinal;
		}
	}
}

