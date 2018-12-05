using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntityController : MonoBehaviour
{
    public Entity entityObject;
    public Team team;
    public GameObject selectionCircle;
    public GameObject unitColorIndicator;
    public NavMeshAgent agent;
    public Animator anim;
    public bool isTasked;
    public GameObject assignedTask;
    public bool isDead = false;

    [Header("Current Values")] 
    public int currentHealth;
    public int currentDamage;

    [HideInInspector] public string objName;
    [HideInInspector] public bool isSelectable;
    [HideInInspector] public Entity.UnitType type;
    [HideInInspector] public int baseHealth;
    [HideInInspector] public int baseDamage;
    [HideInInspector] public string description;
    [HideInInspector] public int value;

    void Awake()
    {
        objName = entityObject.ObjName;
        isSelectable = entityObject.IsSelectable;
        type = entityObject.Type;
        baseHealth = entityObject.BaseHealth;
        baseDamage = entityObject.BaseDamage;
        description = entityObject.Description;
        value = entityObject.Value;
        currentHealth = baseHealth;
        currentDamage = baseDamage;
        selectionCircle.GetComponent<SpriteRenderer>().color = team.Color;
        unitColorIndicator.GetComponent<MeshRenderer>().material.color = team.Color;
        agent.speed = entityObject.defaultSpeed;
    }

    void Update()
    {
        if (agent != null)
        {
            if (isTasked)
            {
                agent.SetDestination(assignedTask.transform.position);
                if (assignedTask.GetComponent<EntityController>().isDead)
                {
                    isTasked = false;
                    assignedTask = null;
                    anim.SetTrigger("Idle");
                }
            }
        }
    }
    
    void OnTriggerStay(Collider other)
    {
        if (isTasked)
        {
            if (other.GetComponent<EntityController>() != null)
            {
                if (other.GetComponent<EntityController>().team.teamAttribute != team.teamAttribute)
                {
                    anim.SetTrigger("Attack");
                }            
            }            
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death(){
        Debug.Log("Object Dead");
        isDead = true;
        gameObject.SetActive(false);
    }

    public void GiveDamage()
    {
        if (isTasked)
        {
            assignedTask.GetComponent<EntityController>().TakeDamage(currentDamage);
        }
    }
}
