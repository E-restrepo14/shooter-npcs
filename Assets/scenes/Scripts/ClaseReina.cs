using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseReina : ClaseEnemigo 
{
	void Start()
	{// al igual que los enemigos tipo soldado... los npc tipo enemigo reina tendran su variable de vida y de daño.
		ReferenciaAgente ();
		vida = 100;
		daño = 31;
	}

}