using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiePina : MonoBehaviour
{
    private NavMeshAgent agente;
    public Transform personaje;
    [SerializeField] private float vida;

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        personaje = GameObject.FindWithTag("personaje").transform;
    }

    private void Start()
    {
        agente.updateRotation = false;
        agente.updateUpAxis = false;    
    }

    private void Update()
    {
       agente.SetDestination(personaje.position);
    }
    public void RecibirDano(float dano)
    {
        vida -= dano;
        if (vida <= 0)
        {
            FindAnyObjectByType<FinJuego>().FinalDeJuego();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("personaje"))
        {
            Personaje Per = collision.GetComponent<Personaje>();
            Destroy(collision.gameObject);

            //Mostrar GameOver
            FindAnyObjectByType<GameOver>().MostrarGameOver();
        }
    }
}
