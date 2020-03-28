using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public CharacterController2D controler;


    private PlayerConrols controls;
    private float horizontalMove = 0;

    public float runSpeed = 40;

    private bool jump = false;
    private bool crouch = false;
    private bool isSwinging = false;
    private bool isFiring = false;

    public Animator animator;

    private Vector2 move;
    private Vector3 velovityCopy;
  
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private Rigidbody2D player_Rigidbody2D;

    private void Awake()
    {
        controls = new PlayerConrols();

        controls.ControllerGamePlay.jump.started += context => Jump_performed(true);

        controls.ControllerGamePlay.walk.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.ControllerGamePlay.walk.canceled += ctx => move = Vector2.zero;

        controls.ControllerGamePlay.crouch.performed += ctx => Crouch_Perfromed();
        controls.ControllerGamePlay.crouch.canceled += ctx => Crouch_Stopped();

        controls.ControllerGamePlay.swing.started += ctx => StartSwing();
        controls.ControllerGamePlay.fire.started += ctx => StartFireball();
    }
    private void OnEnable()
    {
        controls.ControllerGamePlay.Enable();
    }
    // Update is called once per frame
    void Update()
    {
        if (isFiring || isSwinging)
        {
            horizontalMove = 0;
        }
        else
        {
            horizontalMove = move.x * runSpeed;
        }
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
    }
    private void FixedUpdate()
    {
        controler.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, animator);
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

    public void MidAnimation(int boolSub)
    {
        isSwinging = false;
        isFiring = false;
        player_Rigidbody2D.velocity = velovityCopy;
        player_Rigidbody2D.gravityScale = 3;
    }
    private void TurnGravityOff()
    {
        velovityCopy = player_Rigidbody2D.velocity;
        player_Rigidbody2D.velocity = Vector3.zero;
        player_Rigidbody2D.gravityScale = 0;
    }

    private void StopButtonSpam(ref bool buttonPress, string triggerWord)
    {
        if (!isFiring && !isSwinging)
        {
            buttonPress = true;
            TurnGravityOff();
            animator.SetTrigger(triggerWord);
        }
    }
    private void StartFireball()
    {
        StopButtonSpam(ref isFiring, "fireball");   
    }

    public void StartSwing()
    {
        StopButtonSpam(ref isSwinging, "swordswing");
    }

    private void Jump_performed(bool buttonPressed)
    {
        if (!isSwinging && !isFiring)
        {
            jump = buttonPressed;
            animator.SetBool("jumping", jump);
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
}
