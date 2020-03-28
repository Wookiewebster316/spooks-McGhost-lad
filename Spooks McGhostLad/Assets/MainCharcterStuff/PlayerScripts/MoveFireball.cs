using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFireball : MonoBehaviour
{
    private float direction;
    public float fireBallSpeed = 5;
    private Plane[] planes;
    private CircleCollider2D objcollider;
   
    // Start is called before the first frame update
    void Start()
    {
       Camera cam = Camera.main;
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        objcollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = fireBallSpeed * direction * Time.deltaTime;
        transform.Translate(new Vector3(t, 0,0));
        if (!GeometryUtility.TestPlanesAABB(planes, objcollider.bounds))
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(float dir)
    {
        //needs to go the opposite direction as the player is drawn to face left instead of right
        direction = dir * -1;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
        }
    }
}
