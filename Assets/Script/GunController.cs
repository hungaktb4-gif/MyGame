using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform firePoint;
    private int speed = 20;
    public ObjectPool bulletPool;
    private bool pickedGun = false;
    public GameObject gunPrefab;
    public Transform hand;
    public GameObject gunInScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gunInScene != null && !pickedGun)
        {
            PickUpGun();
        }
        if (Input.GetMouseButtonDown(0) && pickedGun)
        {
            Shoot();
        }
    }
    void PickUpGun()
    {
        float distance = Vector2.Distance(transform.position, gunInScene.transform.position);
        if (distance < 2)
        {
            pickedGun = true;
            gunInScene.transform.SetParent(hand);
            gunInScene.transform.localPosition = Vector3.zero;
            gunInScene.transform.localScale = Vector3.one;
            SpriteRenderer sr = gunInScene.GetComponent<SpriteRenderer>();
            if(sr != null)
            {
                sr.sortingOrder = 50;
            }
        }
    }
    void Shoot()
    {
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = firePoint.position;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right*speed;
    }
}
