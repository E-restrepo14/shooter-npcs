using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ClaseEnemigo : ClaseNpc 
{
	// todos los npc tipo enemigo... podran hacer daño, a diferencia de los aliados, por eso se crea esta como una variable que almacena el daño que puede hacer.
	public float daño;
	public GameObject particulasenemigas;

	// todos los enemigos que hereden de esta clase tendran que instanciar este tipo de particulas, por eso se establecen como game object y se guardan dentro de una variable para que puedan ser invocadas

}
