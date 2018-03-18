using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	// este es un singleton que se utilizara para llamar estas funciones desde cualquier clase
	public static GameManager Instance;

	private void Awake ()
	{// aqui se asegurara de que solo haya un singleton en escena
		if (Instance == null)
		{
			Instance = this;
		} 
		else 
		{
			Destroy (this);
		}
	}
	//=============================================================================


	public int count = 50;
	public Text WinText;
	public int npcvivos = 4;

	public GameObject particles1;
	public GameObject particlesAlly;

	// estos son los sprites que se activaran despues de haber eliminado a un enemigo
	// y tambien  habra una variable de cuantos civiles han sido salvados, esta se utilizara para dar un puntaje despues de terminar el nivel.
	public Image civilesSprite;
	public Image civilesSprite2;
	public Image excivilesSprite;
	public Image excivilesSprite2;
	public Image reinasprite;
	public Image enemysprite;
	public int civilessalvados = 0;

	void Update()
	{
		// las condiciones para ganar el nivel son... ya sea rescatando los civiles o matando a todos los enemigos
		if (count > 99) 
		{
			WinText.enabled = true;
		}
		if (npcvivos <= 0) 
		{
			WinText.enabled = true;
		}
	}
	 
	// los siguientes son los metodos que se activaran ya sea por un ontriggerenter de una bala... o un trigger collision de la clase destructor
	public void matoreina (Transform transformReina)
	{
		
		Instantiate (particles1,transformReina.position,transformReina.rotation);
		Destroy (transformReina.gameObject);

		reinasprite.enabled = true;

		npcvivos--;

	}

	public void matosoldado (Transform transformSoldado )
	{
		
		Instantiate (particles1, transformSoldado.position, transformSoldado.rotation);
		Destroy (transformSoldado.gameObject);

		enemysprite.enabled = true;

		npcvivos--;

	}
}
