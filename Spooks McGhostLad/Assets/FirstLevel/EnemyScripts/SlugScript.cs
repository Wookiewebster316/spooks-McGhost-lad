using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugScript : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private float slugSpeed;
    private bool dead = false;
    private float direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = transform.localScale.x * -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            float t = slugSpeed * direction * Time.deltaTime;
            transform.Translate(new Vector3(t, 0, 0));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {

            case "Player":
                direction = direction * -1;
                Flip();
                break;
            default:
                break;
        }
    }

    private void Flip()
    {
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private IEnumerator KillSlug(float waitTime)
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
        //maybe later
        //animator.SetBool("dead", true);
        dead = true;
        Destroy(GetComponent<BoxCollider2D>());
        StartCoroutine("KillSlug", 0.1f);
    }
}
