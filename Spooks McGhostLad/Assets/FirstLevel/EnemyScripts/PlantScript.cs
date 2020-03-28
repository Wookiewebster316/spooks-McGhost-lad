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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case "Player":
                Debug.Log("take player damage");
                break;

            case "Weapon":
                Debug.Log("take plant damage");
                break;
            default:
                break;
        }
    }

    public void PlantFire()
    {
        GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, Quaternion.identity);
        fireball.GetComponent<MoveFireball>().SetDirection(transform.localScale.x);
    }

    public void FlipPlant()
    {
        if (playerObject.transform.position.x < transform.position.x)
        {
            //flip the scale
        }
        if (playerObject.transform.position.x > transform.position.x)
        {
            //flip the scale
        }


    }
}
