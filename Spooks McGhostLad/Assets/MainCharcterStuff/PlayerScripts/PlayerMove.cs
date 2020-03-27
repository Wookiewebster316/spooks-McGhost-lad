using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public CharacterController2D controler;


    private PlayerConrols controls;
    private float horizontalMove = 0;
    private float gravityCopy;

    public float runSpeed = 40;

    private int rechargeTime = 2;
    private int time = 0;

    private bool jump = false;
    private bool crouch = false;

    public Animator animator;

    private Vector2 move;
  
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private Rigidbody2D player_Rigidbody2D;

    private void Awake()
    {
       
        controls = new PlayerConrols();

        controls.ControllerGamePlay.jump.started += context => Jump_performed(true);
        controls.ControllerGamePlay.jump.canceled += context => Jump_performed(false);

        controls.ControllerGamePlay.walk.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.ControllerGamePlay.walk.canceled += ctx => move = Vector2.zero;

        controls.ControllerGamePlay.crouch.performed += ctx => Crouch_Perfromed();
        controls.ControllerGamePlay.crouch.canceled += ctx => Crouch_Stopped();

        controls.ControllerGamePlay.swing.performed += ctx => SwordSwing(true);
        controls.ControllerGamePlay.swing.canceled += ctx => SwordSwing(false);
        

        controls.ControllerGamePlay.fire.performed += ctx => FireBall(true);
        controls.ControllerGamePlay.fire.canceled += ctx => FireBall(false);


    }

    private void Start()
    {
        gravityCopy = player_Rigidbody2D.gravityScale;
    }
    public void MidAnimation(int boolSub)
    {
        if (boolSub == 0)
        {
            controls.ControllerGamePlay.Enable();
            player_Rigidbody2D.IsAwake();
        }
        else if (boolSub == 1)
        {
            controls.ControllerGamePlay.Disable();
        }
    }

    public void Jumping(bool jumping)
    {

    }
    private void SwordSwing(bool swing)
    {
        animator.SetBool("swing", swing);
        player_Rigidbody2D.IsSleeping();
    }

    private void FireBall(bool shoot)
    {
        animator.SetBool("fireOne", shoot);
        player_Rigidbody2D.IsSleeping();
    }
    private void OnEnable()
    {
        controls.ControllerGamePlay.Enable();
    }

    private void Jump_performed(bool buttonPressed)
    {
        if (buttonPressed)
        {
            jump = buttonPressed;
            animator.SetBool("jumping", jump);
        }
        else
        {
            jump = false;
        }
       
    }
    private void Crouch_Perfromed()
    {
        crouch = true;
        animator.SetBool("crouching", true);
    }

    private void Crouch_Stopped()
    {
        crouch = false;
        animator.SetBool("crouching", false);
    }


    // Update is called once per frame
    void Update()
    {
        horizontalMove = move.x * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
    }
    public void OnLand()
    {
        animator.SetBool("jumping", false);
    }
    private void FixedUpdate()
    {
        controler.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private void OnDisable()
    {
        controls.ControllerGamePlay.Disable();
    }

    public void CreateFireball()
    {
        GameObject fireball = Instantiate(fireballPrefab, spawnPoint.transform.position, Quaternion.identity);
        fireball.GetComponent<MoveFireball>().SetDirection(transform.localScale.x);
    }
}
