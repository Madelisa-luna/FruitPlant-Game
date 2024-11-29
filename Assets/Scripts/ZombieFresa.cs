using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieFresa : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float fuerzaRebote = 5f;

    public Transform personaje;
    private NavMeshAgent agente;
    //private Animator anim;
    private BoxCollider2D colFresa;
    private ControladorEnemigos enemigos;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        agente = GetComponent<NavMeshAgent>();
        //anim = GetComponentInChildren<Animator>();
        colFresa = GetComponent<BoxCollider2D>();
        enemigos = FindObjectOfType<ControladorEnemigos>();
    }
    private void Start()
    {
        agente.updateRotation = false;
        agente.updateUpAxis = false;
        personaje = GameObject.FindWithTag("personaje").transform;
    }
    private void Update()
    {
        agente.SetDestination(personaje.position);
        //anim.SetFloat("camina", 2);
    }

    public void RecibirDano(float dano)
    {
        vida -= dano;
        if (vida <= 0)
        {
            enemigos.EnemigoEliminado(1);
            Destroy(gameObject);
            Retroceder();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("personaje"))
        {
            Personaje Per = collision.GetComponent<Personaje>();
            Per.CausarHerida();
            //Destroy(collision.gameObject);
        }
    }

    private void Retroceder() 
    { 
        Vector2 direccion = (transform.position - personaje.position).normalized; 
        rb.AddForce(direccion * fuerzaRebote, ForceMode2D.Impulse); 
    }
}
