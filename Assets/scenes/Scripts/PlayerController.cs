using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour 
	{	// para controlar al jugador, se crearon las variables de vida, y velocidad de movimiento
		public float speed = 6.0F;
		public float horizontalSpeed = 5.0F;
		public float PlayerLife = 40;

	// y dependiendo de las acciones del jugador se activaran y desactivaran los sprites del hud... 3 vidas y el pickup de un arma mejorada y un escudo
	public Image GunSprite;
	public Image TankSprite;
	public Image life1sprite;
	public Image life2sprite;
	public Image life3sprite;
	//======================================================

	float contador = 5;
	// esta variable se utiliza para que al jugador no le baje la vida tan rapido al estar en contacto con el enemigo
	// tambien instanciará esta particula por estetica y para que se vea que esta reciviendo daño
	public GameObject particlesEnemy;

	public GameObject[] proyectiles;
	// dependiendo de si el jugador recoja o no el pickup del arma... este disparará dos tipos de bala... que se almacenaran en este array.
	public GameObject proyectil;
	// proyectil será una de los dos tipos de balas que se disparará

	public Transform shotSpawn;	// y este es el lugar desde donde saldra la bala

	//========================================================
	public GameObject extraweapons;
	public GameObject escudo;
	// estos son los pick ups del arma y de un escudo que se recogeran luego
	//========================================================
	//estas variables son para evitar que la nave dispare mil balas por segundo
	public float fireRate;
	private float nextFire;

	//inicialmente el escudo y la superarma estaran desactivadas y disparara balas normales
	void Start ()
	{
		escudo.SetActive (false);
		extraweapons.SetActive (false);
		// a proyectil se le asigna ser de la bala pequeña... un prefab almacenado en la posicion 0 de []proyectiles
		proyectil = proyectiles [0];

	}

	// este es para ordenar al jugador que hacer cuando entra al collider de los pick ups
	void OnTriggerEnter (Collider other)
	{// aqui ordenamos disparar la superbala cuando el item de la superarma es recogido
		if (other.gameObject.CompareTag ("Extraweapon"))
		{	extraweapons.SetActive (true);
			proyectil = proyectiles [1];
			// y eliminar el item colectable despues de recogerlo para que no estorbe en la escena
			Destroy ( other.gameObject);
			GunSprite.enabled = true;
		}



		// igualmente aqui pero con el pick up del escudo
		if (other.gameObject.CompareTag ("Shield"))
		{	escudo.SetActive (true);
			Destroy ( other.gameObject);
			TankSprite.enabled = true;
			PlayerLife = 90f;
		}
			
	}

	// en este bloque de codigo se encarga de revajar la vida del personaje dependiendo del tipo de enemigo que se encuentre
	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.CompareTag ("EnemyInfectador")) {
			Instantiate (particlesEnemy, transform.position, transform.rotation);
			// cuando entre el contacto... el jugador instanciara particulas de ser convertido por el enemigo

			if (Time.fixedTime > contador) {
				contador = Time.fixedTime + 3.0f;
				PlayerLife = PlayerLife - 5.0f;

				// y cuando la vida llegue a cero el personaje se desaparecera y se cambiara el tag para que los npcs enemigos buelvan a patrullar
				if (PlayerLife <= 0) {
					gameObject.tag = "Enemy";
					gameObject.SetActive(false);
				
				}
			}
		}

		if (other.gameObject.CompareTag ("Enemy")) {
			Instantiate (particlesEnemy, transform.position, transform.rotation);
			// esto es lo mismo que el anterior pero en este caso la vida que baja sera menor.
			if (Time.fixedTime > contador) {
				contador = Time.fixedTime + 3.0f;
				PlayerLife = PlayerLife - 2.5f;
				if (PlayerLife <= 0) {
					gameObject.tag = "Enemy";
					gameObject.SetActive(false);
			
				}
			}
		}

	}

	void Update() 
		{// este codigo se encarga de que se dispare una cierta cantidad de balas en cierto tiempo para eso se utilizaran las variables next fire y firerate
		//el time.time sera mayor que next fire y se aplicara el if
			if(Input.GetButton("Fire1")&& Time.time > nextFire)
			{
			// aqui se le suma un valor al next fire... haciendo que se deba esperar unos segundos antes de que se pueda ingrasar a este if nuevamente
				nextFire = Time.time + fireRate;

			// Se instancia el proyectil desde el cañon... ya sea de la bala normal o la super bala.
			Instantiate (proyectil,shotSpawn.position,shotSpawn.rotation);

			}

			// este se metio dentro de un update porque se debe verificar en todo momento la vida del personaje
		    //dentro de este codigo tambien se controla el enable  de las imagenes del hud de vidas.
		if (PlayerLife <= 30) {life3sprite.enabled = false;
				}
		if (PlayerLife <= 20) {life2sprite.enabled = false;
				}
		if (PlayerLife <= 10) {life1sprite.enabled = false;
				}
		}




	// esta parte del codigo es para mover la nave por el mapa con las axis y el movimiento del mouse.
		void FixedUpdate() 
		{
		float translation = Input.GetAxis("Vertical")*speed;
		float htranslation = Input.GetAxis("Horizontal")* speed;
		translation *= Time.deltaTime;
		htranslation *= Time.deltaTime;

		transform.Translate (htranslation,0, translation);





		// esta parte del codigo hace rotar la nave mediante el movimiento del mouse
			float h = horizontalSpeed * Input.GetAxis("Mouse X");

			transform.Rotate(0, h, 0);
		}
	}

