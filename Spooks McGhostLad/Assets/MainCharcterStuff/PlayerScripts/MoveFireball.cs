using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFireball : MonoBehaviour
{
    private float direction;
    public float fireBallSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = fireBallSpeed * direction * Time.deltaTime;
        transform.Translate(new Vector3(t, 0,0));
    }

    public void SetDirection(float dir)
    {
        direction = dir * -1;
    }
}
