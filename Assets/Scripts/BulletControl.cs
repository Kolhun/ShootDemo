using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    
    public int damage = 25;
    public Rigidbody rigidBody;
    public float fadeTime = 3f;
    public float force = 2000f;
    void OnTriggerEnter(Collider trigger)
    {

        if(trigger.tag == "Entity")
        {
         
            Entity entity = trigger.GetComponentInParent<Entity>();
            entity.Damage(damage);

        }
        Fade();
    }

    public void Shoot(Vector3 startPos, Vector3 endPos)
	{
        gameObject.SetActive(true);
        transform.position = startPos;
        transform.forward = (endPos - startPos).normalized;
        rigidBody.AddForce(transform.forward * force);
        StartCoroutine(FadeTime());
    }
    void Fade()
	{
        rigidBody.velocity = Vector3.zero;
        gameObject.SetActive(false);
	}
    IEnumerator FadeTime()
	{
        yield return new WaitForSeconds(fadeTime);
        Fade();
    }
    


}
