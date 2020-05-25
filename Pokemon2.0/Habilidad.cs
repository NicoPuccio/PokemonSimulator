using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonParcial1
{
    public abstract class Habilidad
    {
		protected Random rnd = new Random();

		private string nombre; 

		protected TipoElemento.eTipo tipo = TipoElemento.eTipo.AGUA;

		public TipoElemento.eTipo Tipo {
    		get {
    			return this.tipo;
    		}
    		set {
    			tipo = value;
    		}
    	}

		public string Nombre {
    		get {
    			return this.nombre;
    		}
    		set {
    			nombre = value;
    		}
    	}

		public abstract void Activar (Pokemon atacante, Pokemon defensor);
	}
}
