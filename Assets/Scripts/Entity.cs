using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Entity : MonoBehaviour
{
    
    [HideInInspector] public EntityController controller;
    [HideInInspector] public Model model;
    public int healthStart = 100;
    [SerializeField] private int health;
    public bool isDead = false;

    void Awake()
    {
        controller = GetComponent<EntityController>();
        model = GetComponentInChildren<Model>();
    }
    void Start()
    {
        health = healthStart;
    }
    

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Kill();
        }
    }
    public void Kill()
    {
        isDead = true;
        controller.Die();
         
    }
}
