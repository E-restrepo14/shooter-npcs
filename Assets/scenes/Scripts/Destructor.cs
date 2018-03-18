using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destructor : MonoBehaviour {



	void Start() 
	{
		SetCountText ();
	}// ya que el setcounttext es llamado varias veces... pero tambien debia ser llamado desde el inicio del juego... lo converti en un metodo aparte y tambien lo llame desde un start...
	public void SetCountText ()
	{
		GameManager.Instance.WinText.text = " has ganado este nivel score:" + GameManager.Instance.count.ToString (); 
	}


	//este codigo es para ponerlo a un escudo que se encarga de colectar civiles rescatados y matar algunos enemigos que se acerquen lo suficiente
	// todo funciona mediante un trigger enter
	void OnTriggerEnter (Collider other)
	{
		

		if (other.gameObject.CompareTag ("EnemyInfectador")) 
		{
			GameManager.Instance.matoreina (other.transform);

		}

		if (other.gameObject.CompareTag ("Enemy")) 
		{ 	
			GameManager.Instance.matosoldado (other.transform);
		
		}
			
		//=================================================
		if (other.gameObject.CompareTag ("civilian")) 
		{
			// en este caso... de ser un civil quien toque el escudo... se instanciara un tipo de particulas diferentes a las de los enemigos 
			Transform otraposicion = other.gameObject.GetComponent<Transform> ();
			Instantiate (GameManager.Instance.particlesAlly, otraposicion.position, otraposicion.rotation);
			Destroy (other.gameObject);
			// en vez de llamar un metodo para destruir/rescatar al ciudadano... se llamara el metodo desde aqui mismo
			GameManager.Instance.civilessalvados++;

			if (GameManager.Instance.civilessalvados == 1) 
			{
				// se cambiaran los enable de los sprites (almacenados en el singleton gamemanager)... para mostrar que el civil fue salvado
				// y se aumentara la cantidad de score por cada npc aliado.
				GameManager.Instance.npcvivos--;

				GameManager.Instance.civilesSprite.enabled = true;
				GameManager.Instance.excivilesSprite.enabled = false;
				GameManager.Instance.count = GameManager.Instance.count + 25;
				SetCountText ();
			
			}
			if (GameManager.Instance.civilessalvados == 2) 
			{
				GameManager.Instance.npcvivos--;

				GameManager.Instance.civilesSprite2.enabled = true;
				GameManager.Instance.excivilesSprite2.enabled = false;
				GameManager.Instance.count = GameManager.Instance.count + 25;
				SetCountText ();
			
			}
		}
	}
}
