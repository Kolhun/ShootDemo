using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
   
    public List<NavPoint> path = new List<NavPoint>();
    public int pathIndex = 0;
    public NavPoint point;
    
    [HideInInspector]public Entity entity;
    public PlayerController controller;
    [SerializeField]
    private NavMeshAgent agent;
    public bool isRotating = false;
    public bool isMoving{ 
        get{ 
            return !agent.isStopped; 
        } 
        set{ 
            agent.isStopped = !value; 
            entity.model.animator.SetBool("Step", isMoving); 
        }}
    void Awake()
	{
        entity = GetComponent<Entity>();
	}
    [ContextMenu("Move")]
    public void Move()
    {
        
        if (pathIndex >= path.Count)
        {
            entity.controller.OnPathEnd();
            return;
        }
        controller.gameCanvas.SetActive(false);
        point = path[pathIndex];
        pathIndex++;
        isRotating = false;
        agent.destination = point.transform.position;
        isMoving = true;
        
      

    }

    IEnumerator waitOnPoint(float time)
    {

        if(point.rotate)
        {
            isRotating = true;
        } 
        yield return new WaitForSeconds(time);
        
    }

    public void Stop()
    {
        isMoving = false;
    }

    void FixedUpdate()
    {
        if(point == null) return;
        if(isMoving)
        {
            var distance = Vector3.Distance(point.transform.position, transform.position);
            if(distance <= 0.2)
            {
                isMoving = false;
                controller.gameCanvas.SetActive(true);
                if (point.waitTime > 0)
                {
                    StartCoroutine(waitOnPoint(point.waitTime));
                } 
            }
        }else if(isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation,point.transform.rotation,agent.angularSpeed * Time.fixedDeltaTime);
            if(transform.rotation == point.transform.rotation)
            {
                isRotating = false;
            }
        }

    }
}
