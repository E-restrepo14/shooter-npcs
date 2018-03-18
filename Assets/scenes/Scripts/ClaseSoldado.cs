using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseSoldado : ClaseEnemigo 
{
	void Start()
	{// los npc tipo enemigo soldado tendran su variable de vida y de daño.
		ReferenciaAgente ();
		vida = 35;
		daño = 7;
	}


}