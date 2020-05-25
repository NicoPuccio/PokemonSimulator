using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonParcial1
{
    public class Pokemon
    {

		/* Orden de miembros / datos de clase (EN Orden):
		 * Enumeraciones y Constantes
		 * miembros (Variables)
		*  Constructores
		*  Metodos
		*  Getters / Setters (Accessors)
		*  Clases Internas */ 

		private List<Habilidad> habilidades; 


		public Pokemon (TipoElemento.eTipo tipo, string nombre, double vida, double velocidad, float fuerza, double armadura, int suerte)
    	{
    		this.tipo = tipo;
    		this.nombre = nombre;
    		this.vida = vida;
    		this.velocidad = velocidad;
    		this.fuerza = fuerza;
    		this.armadura = armadura;
    		this.suerte = suerte;
			habilidades = new List<Habilidad> ();


    	}
			
		public void ActivarHabilidad (Habilidad habilidad, Pokemon defensor){
			if (this.habilidades.Contains (habilidad))
				habilidad.Activar (this, defensor);
			else
				throw new Exception ("Este pokemon no cuenta con esa habilidad!");
		}

		public void AgregarHabilidad(Habilidad habilidad)
		{
			if (this.habilidades.Count == 3)
				throw new Exception ("Este Pokemon ya tiene sus 3 habilidades!");
			this.habilidades.Add (habilidad);
		}

		public Habilidad ObtenerHabilidadPorIndice(int index){
			return habilidades [index];
		}

		public List<string> ObtenerListaNombreHabilidades(){
			List<string> lista = new List<string> ();
			int i = 0;

			foreach(Habilidad h in habilidades)
			{
				lista.Add (h.Nombre);
				i++;

			}

			return lista;
		}

		public bool EstaMuerto(){
			return (this.vida <= 0);
		}

        public List<string> MostrarStatsPokemon()
        {
            List<string> stats = new List<string>();
            stats.Add("Stats: ");
            stats.Add(this.Nombre);
            stats.Add(" | Vida: " + this.Vida.ToString());
            stats.Add(" | Velocidad: " + this.Velocidad.ToString());
            stats.Add(" | Fuerza: " + this.fuerza);
            stats.Add(" | Armadura: " + this.armadura);
            stats.Add(" | Suerte: " + this.suerte);
            Console.WriteLine();
            return stats;
        }

		private TipoElemento.eTipo tipo;

		public TipoElemento.eTipo Tipo {
    		get {
    			return this.tipo;
    		}
    		set {
    			tipo = value;
    		}
    	}

		private string nombre;

        public string Nombre
        {
            get
            {
                return nombre;
            }
        }

        private double vida;

        public double Vida
        {
            get
            {
                return vida;
            }

            set
            {


				vida = value;


				if(vida < 0)    //Como hago para que la vida no aparezca negativa?
				{
					vida = 0;
				}
            }
        }
			
       
        private double velocidad;

        public double Velocidad
        {
            get
            {
                return velocidad;
            }

            set
            {
                velocidad = value;
            }
        }

        private double fuerza;

        public double Fuerza
        {
            get
            {
                return fuerza;
            }

            set
            {
                fuerza = value;
            }
        }

        private double armadura;

        public double Armadura
        {
            get
            {
                return armadura;
            }
            set
            {
                armadura = value;
            }
        }
			
		private int suerte;

		public int Suerte {
    		get {
    			return this.suerte;
    		}
    		set {
    			suerte = value;
    		}
    	}

    }
}
