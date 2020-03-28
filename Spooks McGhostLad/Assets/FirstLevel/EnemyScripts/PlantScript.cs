using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private float time;

    [SerializeField] private float rechargeTime = 3f;
    [SerializeField] private Transform fireballSpawnPoint;
    [SerializeField] private GameObject fireballPrefab;
    private GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > rechargeTime)
        {
            time = 0;
            animator.SetTrigger("plantAttack");
        }
        FlipPlant();
    }
    private IEnumerator KillPlant(float waitTime)
    {
        Renderer render = GetComponent<Renderer>();
       
        Color colour = render.material.color;
        float aplha = colour.a;
        for (int ft = 0; ft < 5; ft++)
        {
            colour.a = 0;
            render.material.color = colour;
            yield return new WaitForSeconds(waitTime);
            colour.a = aplha;
            render.material.color = colour;
            yield return new WaitForSeconds(waitTime);
        }
        Destroy(gameObject);
    }
    public void DestoryEnemy()
    {
        animator.SetBool("dead", true);
        Destroy(GetComponent<BoxCollider2D>());
        StartCoroutine("KillPlant", 0.1f);
    }

    public void PlantFire()
    {
        GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, Quaternion.identity);
        fireball.GetComponent<MoveFireball>().SetPlantFire(transform.localScale.x);
    }


    private Vector3 Flip(float dir)
    {
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x = dir;
        return theScale;
    }
    
    public void FlipPlant()
    {
        if (playerObject.transform.position.x < transform.position.x)
        {
            transform.localScale = Flip(1);
        }
        else if (playerObject.transform.position.x > transform.position.x)
        {
            transform.localScale = Flip(-1);
        }


    }

}
