using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{

    NavMeshAgent agent;
    public GameObject player;
    public List<Transform> ruta;

    private int puntoRuta = 0;
    private float speedChasing;
    private float speedNoChasing;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent> ();
        speedChasing = agent.speed * 2;
        speedNoChasing = agent.speed;
        SeleccionarRuta();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x == ruta[puntoRuta].position.x && transform.position.z == ruta[puntoRuta].position.z){
            ActualizarRuta();
        }
        if(Vector3.Distance(transform.position, player.transform.position) < 10){
            agent.destination = player.transform.position;
            agent.speed = speedChasing;
        }else{
            agent.speed = speedNoChasing;
            SeleccionarRuta();
        }
    }

    private void SeleccionarRuta(){
        agent.destination = ruta[puntoRuta].position;
    }

    private void ActualizarRuta(){
        if (puntoRuta == (ruta.Count) - 1){
            puntoRuta = 0;
        }else {
            puntoRuta++;
        }

        SeleccionarRuta();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag.Equals("Player")){
            Debug.Log("Golpe");
        }
    }

}
