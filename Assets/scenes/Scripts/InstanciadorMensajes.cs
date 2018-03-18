using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstanciadorMensajes : MonoBehaviour 
{
	public Text Instruccion1;
	public Text Instruccion2;

	// estas dos variables seran las instrucciones que apareceran cuando el protagonista se acerque a la nave nodriza


	void Start ()
	{
		Instruccion1.text = "soldado!!! has sobrevivido a la tormenta espacial... que bueno, pero " +
			"los civiles andan por ahi dispersados... encuentralos y traelos... " ; 
		Instruccion2.text = "los aliens que rondan por ahi te perseguiran y te mataran... si los " +
			"llevas hacia los civiles... serán convertidos en aliens tambien, " +
			"si te encuentras con una reina... no la mataras nunca con tus armas normales"; 
	// se les asigna los mensajes a mostrar a cada una de las variables en el Start
	}

	void OnTriggerStay (Collider other) 
	{ if (other.gameObject.CompareTag ("instruccion1")) 
		{
			Instruccion1.enabled = true;
		}
		if (other.gameObject.CompareTag ("instruccion2")) 
		{
			Instruccion2.enabled = true;
		}
	// y estas se activaran y desactivaran cuando el protagonista entre y salga de dos colliders con los tags instruccion 1 e instruccion 2
	}



	void OnTriggerExit (Collider other) 
	{ if (other.gameObject.CompareTag ("instruccion1")) 
		{
			Instruccion1.enabled = false;
		}
		if (other.gameObject.CompareTag ("instruccion2")) 
		{
			Instruccion2.enabled = false;
		}

	}
}
