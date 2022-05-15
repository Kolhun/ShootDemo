using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : EntityController
{

    public BulletPool bulletPool;
    public Transform bulletExe;
    public LayerMask shootMask;
    public bool canShoot = false;
    public Navigation navigation;
    public GameObject startCanvas;
    public GameObject gameCanvas;
    public GameObject nextLevelCanvas;
    public GameObject dieCanvas;
    


    public override void Awake()
    {
        base.Awake();
        navigation = GetComponent<Navigation>();
    }
    public override void Die()
    {
        navigation.Stop();
        entity.model.animator.Play("Die");
    }

    public override void OnDieEnd()
    {

        gameCanvas.SetActive(false);
        nextLevelCanvas.SetActive(false);
        dieCanvas.SetActive(true);
        
    }

    public void RestartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void StartMove()
	{
        startCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        navigation.Move();
        canShoot = true;
    }

    public void ShowNextLevelCanvas()
    {
        gameCanvas.SetActive(false);
        nextLevelCanvas.SetActive(true);
    }
	public override void OnPathEnd()
	{
        ShowNextLevelCanvas();
        canShoot = false;
    }


    void Update()
    {
        if(entity.isDead || !canShoot) return;
        if(Input.GetButtonDown("Fire1"))
        {
            if(!EventSystem.current.IsPointerOverGameObject())
            {
                var mousePosition = Input.mousePosition;
                mousePosition.z = 10;
                var targetPos = Camera.main.ScreenToWorldPoint(mousePosition);
                var originPos = Camera.main.transform.position;
                if(Physics.Raycast(originPos, targetPos - originPos, out RaycastHit hit, shootMask))
                {

                    var bullet = bulletPool.GetPoolBullet();
                    bullet.Shoot(bulletExe.position,hit.point);

                }
            }
        }
    }
}
