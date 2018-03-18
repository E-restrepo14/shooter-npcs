using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClaseNpc : MonoBehaviour 
{
	// todos los npc para patrullar... necesitan un array de emptys para llegar a sus posiciones como si hicieran una ruta. para ello tambien necesitan su propio navmeshagent y adicionalmente su variable de vida.
	public Transform[] Waypoints;
	public NavMeshAgent navmeshagent;
	public float vida;

	// siguientewaypoint se encarga de cambiar el empty al cual se dirigira el npc cuando esta patrullando
	private int SiguienteWaypoint;
	protected bool estaSiguiendo;
	// estasiguiendo es para desactivar un metodo y activar otro en su lugar... es para hacer que el npc suspenda su actividad de patrullaje e inicie la persecucion del protagonista... ya sea el npc un enemigo o un aliado.
	protected Transform target;


	void Update ()
	{
		if (estaSiguiendo) {
			Seguir (target);
		} else {
			EstaPatrullandencio ();
		}
	}

	// esto es para poder acceder al los navmeshagent de los gamobjects que posean este script
	public void ReferenciaAgente ()
	{
		navmeshagent = GetComponent <NavMeshAgent> ();
	}


	public void EstaPatrullandencio()
	{//siempr que se este patrullando se llamara el metodo de actualizarwaypointdestino, pero si ha llegado al destino, se cambiará al siguiente en la lista del array
		if (HemosLlegado ()) 
		{
			SiguienteWaypoint = (SiguienteWaypoint + 1) % Waypoints.Length;
			ActualizarWaypointDestino ();
		}

		ActualizarWaypointDestino ();
	}


	// mediante el triggerenter se descubrira si el npc ha detectado al jugador y se cambiara el booleano esta siguiendo y se asignara un nuevo target para el navmeshagent
	public void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			target = other.transform;
			estaSiguiendo = true;
		}
	}

	public void OnTriggerExit (Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			target = null;
			estaSiguiendo = false;
		}
	}
	//=====================================================================================

	// este metodo se llamara solo cuando el player persiga al jugador... y aun asi lo alcance... siempre este esperando al momento en que este se mueve para seguirlo nuevamente.
	public void ActualizarPuntoDestinoNavMeshAgent(Transform PuntoDestino)
	{
		navmeshagent.destination = PuntoDestino.position;
		navmeshagent.isStopped = false;
	}

	// este metodo debolverá un valor de falso o verdadero si el npc ha llegado ya a su destino
	public bool HemosLlegado ()
	{
		return navmeshagent.remainingDistance <= navmeshagent.stoppingDistance && !navmeshagent.pathPending;      
	}

	public void ActualizarWaypointDestino ()
	{
		ActualizarPuntoDestinoNavMeshAgent (Waypoints[SiguienteWaypoint]);
	}


	public void PerderVida(float dañoARecivir)
	{
		vida -=dañoARecivir;
	}


	public void Seguir(Transform objetivo)
	{
		navmeshagent.SetDestination (objetivo.position);
	}

}
