using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonParcial1
{
    public class ScaryFace : Habilidad
    {
        private const double REDUCCION_VELOCIDAD_SCARYFACE = 10;
        public ScaryFace ()
    	{
			this.Nombre = "Scary Face";
    	}
    	
        public override void Activar(Pokemon atacante, Pokemon defensor)
        {
            double reduccionVelocidadFinal = REDUCCION_VELOCIDAD_SCARYFACE; // no hacia falta en realidad
            defensor.Velocidad -= reduccionVelocidadFinal;
        }
    }
}
