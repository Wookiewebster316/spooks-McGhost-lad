using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFireball : MonoBehaviour
{
    private float direction;
    public float fireBallSpeed = 5;
    private Plane[] planes;
    private CircleCollider2D objcollider;
    [SerializeField] LayerMask hitmask;

    public float radius;
   
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
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public void SetDirection(float dir)
    {
        //needs to go the opposite direction as the player is drawn to face left instead of right
        direction = dir * -1;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius, hitmask);

        for (int i = 0; i < hits.Length; i++)
        {
            switch (hits[i].transform.tag)
            {
                case "Enemy":
                    Destroy(hits[i].gameObject);
                    Destroy(gameObject);
                    break;

                case "Player":
                    Destroy(gameObject);
                    break;

                case "Sheild":
                    Destroy(gameObject);
                    break;

                default:
                    break;
            }
        }


    }
}
