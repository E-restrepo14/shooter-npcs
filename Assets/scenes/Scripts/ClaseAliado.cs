using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClaseAliado : ClaseNpc 
{
	public GameObject particulasenemigas;
	public GameObject tapa1;
	public GameObject tapa2;
	float contador = 5.0f;

	void Start()
	{
		ReferenciaAgente ();
		vida = 30;
	}


	// el aliado al ser convertido... no cambiara nada su clase, solo cambiara sus colores y su tag, el mismo civil es quien se encarga de bajar su propia vida cuando se encuentra con un npc enemigo
	// pero en caso de ser un enemigo tipo reina este se convertira instantaneamente.

	void OnTriggerStay (Collider other)
	{//  en caso de que se convierta en enemigo... no necesitamos que siga recibiendo daño de otros enemigos, asi que todas las instrucciones se meten dentro del condicional.. que el npc sea de tag "civilian"
		if (gameObject.tag == "civilian") 
		{
			if ((other.gameObject.CompareTag ("Enemy"))) 
			{
				Instantiate (particulasenemigas,transform.position,transform.rotation);
				if (Time.fixedTime > contador) 
				{// siempre que entre en contacto con un enemigo se instanciaran las particulas del enemigo, y el contador y los gameobjects del principio son para evitar que reciba daño por cada frame y que se cambien a los colores del enemigo
					contador = Time.fixedTime + 3.0f;
					vida-= 5;
					if (vida<0)
					{
						// ya que solo los aliados pueden convertirse... este metodo de ser convertidos solo existe dentro de la clase aliado
						gameObject.tag = "Enemy";
						tapa1.GetComponent<Renderer> ().material.color = new Color (0.25f, 0f, 0.5f, 1f);
						tapa2.GetComponent<Renderer>().material.color = new Color (0.25f, 0f, 0.5f, 1f);
					}
				}
			}


			if ((other.gameObject.CompareTag ("EnemyInfectador"))) 
			{
				gameObject.tag = "Enemy";
				tapa1.GetComponent<Renderer> ().material.color = new Color (0.25f, 0f, 0.5f, 1f);
				tapa2.GetComponent<Renderer>().material.color = new Color (0.25f, 0f, 0.5f, 1f);
			}
		}
	}
}
