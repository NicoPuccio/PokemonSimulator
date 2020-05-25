using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonParcial1
{
    class Program
    {
	
		private static Pokemon ElegirPokemon(List<Pokemon> pokemonesParaElegir){
			int i = 0;
			foreach(Pokemon p in pokemonesParaElegir)
			{
				Console.WriteLine(i + ") "+ p.Nombre);
				i++;
			}
			int opcion = int.Parse(Console.ReadLine());
			return pokemonesParaElegir[opcion];
		}

        static void Main(string[] args)
        {
            Habilidad bolaDeFuego = new BolaDeFuego();
            Habilidad chorroDeAgua = new ChorroAgua();
            Habilidad latigo = new Latigo();
            Habilidad gruñido = new Gruñido();
            Habilidad scaryFace = new ScaryFace();
            Habilidad latigoCepa = new LatigoCepa();
            Habilidad Terremoto = new Terremoto();

            List<Pokemon> pokemons = new List<Pokemon>();

            Pokemon charmander = new Pokemon(TipoElemento.eTipo.FUEGO, "Charmander", 100, 50, 40, 50, 10);
            charmander.AgregarHabilidad(bolaDeFuego);
            charmander.AgregarHabilidad(gruñido);
            charmander.AgregarHabilidad(latigo);


            Pokemon squirtle = new Pokemon(TipoElemento.eTipo.AGUA, "Squirtle", 100, 40, 35, 60, 5);
            squirtle.AgregarHabilidad(chorroDeAgua);
            squirtle.AgregarHabilidad(latigo);
            squirtle.AgregarHabilidad(scaryFace);

            Pokemon onix = new Pokemon(TipoElemento.eTipo.TIERRA, "Onix", 100, 40, 35, 60, 5); 
            onix.AgregarHabilidad(Terremoto);
            onix.AgregarHabilidad(latigo);
            onix.AgregarHabilidad(scaryFace);

            Pokemon bulbasaur = new Pokemon(TipoElemento.eTipo.PLANTA, "Bulbasaur", 100, 40, 35, 60, 5);
            bulbasaur.AgregarHabilidad(latigoCepa);
            bulbasaur.AgregarHabilidad(latigo);
            bulbasaur.AgregarHabilidad(scaryFace);

            pokemons.Add(charmander);
            pokemons.Add(squirtle);
            pokemons.Add(onix);
            pokemons.Add(bulbasaur);



            //Consultar Pokemones.
			Console.WriteLine(" Entrenador 1 elija su pokemon: ");
			Pokemon pokemon1 = ElegirPokemon(pokemons);
            Console.WriteLine(" Eligio a {0}", pokemon1.Nombre);

            Console.WriteLine(" Entrenador 2 elija su pokemon: ");
			Pokemon pokemon2 = ElegirPokemon (pokemons);
            Console.WriteLine(" Eligio a {0}", pokemon2.Nombre);

            Pokemon ganador = IniciarCombate(pokemon1, pokemon2);

            Console.WriteLine();
			Console.WriteLine("El ganador del combate fue {0}", ganador.Nombre);
            Console.ReadLine();
        }
        
		//Ciclo de Combate : 2 Pokemones - Uno va a ser primero, otro segundo (Dependiendo la Speed)  - DONE
		//Decidis quien es primero y quien segundo - DONE
		//Ejecutamos los turnos, es decir, en cada turno, el pokemon en cuestion activa una habilidad.
		//Ejecutas turno del primero (Consultas que habilidad usar) //DONE
		//Ejecutas turno del segundo (idem) //DONE
		//Al final de cada turno (Tanto atacante como defensor) chequeas si alguno murio. En tal caso, salis del loop.
		//Volves al loop.
		//Pokemon de retorno = Pokemon ganador.

		public static Pokemon IniciarCombate(Pokemon pokemon1, Pokemon pokemon2){
			Pokemon primero;
			Pokemon segundo;
            while (true) {
                if (pokemon1.Velocidad > pokemon2.Velocidad) {
                    //pokemon 1 es primero, pokemon 2 es segundo.
                    primero = pokemon1;
                    segundo = pokemon2;
                } else {
                    //pokemon 2 es primero, pokemon 1 es segundo.
                    primero = pokemon2;
                    segundo = pokemon1;
                }

                Habilidad habilidadPrimero = null;
                Habilidad habilidadSegundo = null;

                //Consultar Habilidad del primero


                Console.WriteLine("Pokemon {0} :", primero.Nombre);
                Console.WriteLine("Habilidades : ");
                int i = 0;
                foreach (string s in primero.ObtenerListaNombreHabilidades()) {
                    Console.WriteLine(i + ") " + s);
                    i++;
                }
                int elegirHabilidad = 0;
                Console.WriteLine(" Elegi la habilidad a usar:");
                //clearInputBuffer ();

                bool result = false;



                //elegirHabilidad = int.Parse(Console.ReadLine ());
                result = int.TryParse(Console.In.ReadLine(), out elegirHabilidad);
                habilidadPrimero = primero.ObtenerHabilidadPorIndice(elegirHabilidad);


                //Tomamos turno del primero.

                primero.ActivarHabilidad(habilidadPrimero, segundo);

                //Imprimir Que paso.
                //TODO: Esta impresion, meterla en una funcion en Pokemon (ImprimirResumen() por ejemplo)
                //Console.WriteLine("Pokemon: {0} Vida: {1}, Velocidad: {2}", primero.Nombre, primero.Vida, primero.Velocidad); 
                //Console.WriteLine("Pokemon: {0} Vida: {1}, Velocidad: {2}", segundo.Nombre, segundo.Vida, segundo.Velocidad); 
                
				FormatearStatsPokemon (primero);
				FormatearStatsPokemon (segundo);
				
                //Evaluamos finalizacion del combate

                if (primero.EstaMuerto ()) {
					return segundo;
				} else if (segundo.EstaMuerto ()) {
					return primero;
				}
                Console.WriteLine();
				Console.WriteLine("Pokemon {0} :", segundo.Nombre);
				Console.WriteLine ("Habilidades : ");
				//Console.WriteLine (charmander.MostrarListaHabilidades ());
				i = 0;
				foreach (string s in segundo.ObtenerListaNombreHabilidades()) {
					Console.WriteLine (i + ") " + s);	
					i++;
				}

				//Consultar Habilidad del segundo
				Console.WriteLine(" Elegi la habilidad a usar:");
				elegirHabilidad = int.Parse(Console.ReadLine ());
				habilidadSegundo = segundo.ObtenerHabilidadPorIndice (elegirHabilidad);

				//Tomamos turno del segundo.
				segundo.ActivarHabilidad (habilidadSegundo, primero);

                //Imprimir que paso
                FormatearStatsPokemon(primero);
                FormatearStatsPokemon(segundo);



                //Evaluamos finalizacion del combate

                if (primero.EstaMuerto ()) {
					return segundo;
				} else if (segundo.EstaMuerto ()) {
					return primero;
				}
                Console.ReadLine();
                Console.Clear();
			}
		}

		public static void FormatearStatsPokemon(Pokemon pokemon){

			foreach (string s in pokemon.MostrarStatsPokemon())
			{
				Console.Write(s);
				Console.Write(" ");
			}

		}

        public static int ElegirPokemon()
        {
            Console.WriteLine(" Jugador 1, elija su pokemon: ");
            int opcion = int.Parse(Console.ReadLine());
            return opcion;
        }

		private static void clearInputBuffer()
		{
			while(Console.KeyAvailable)
			{
				Console.Read(); // read next key, but discard
			}
		}

       
    }
}

