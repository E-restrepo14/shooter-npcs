using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorBullet : MonoBehaviour 
{


	public float bulletSpeed;
	public Rigidbody rgbdy;




	void Start ()
	{
		// al momento de aparecer la bala... utilizando su rigidbody... se le da un impulso hacia su eje z...
		rgbdy.velocity = transform.forward* bulletSpeed;

	}

	void OnCollisionEnter(Collision other)
	//esto es para destruir la bala cuando colisiona con algo
	{
	Destroy (gameObject);

		// pero si la bala choca contra un enemigo... este tambien se destruirá e instanciará unas particulas de impacto.
		// en el if siguiente a este... solo se aplicara estas instrucciones si la bala que lleva el script... es la version grande y con tag diferente
		if (other.gameObject.CompareTag ("Enemy")) 
		{

			GameManager.Instance.matosoldado (other.transform);
		

		}

		if (other.gameObject.CompareTag ("EnemyInfectador")) 
		{
			if (gameObject.tag == "bigshot")
			{
				GameManager.Instance.matoreina (other.transform);

			}
		}
	}
}