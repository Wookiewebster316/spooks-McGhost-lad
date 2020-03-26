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

    public Animator animator;

    private Vector2 move;
  
    [SerializeField] private Transform pos;

    private void Awake()
    {
        controls = new PlayerConrols();

        controls.ControllerGamePlay.jump.started += context => Jump_performed();
        controls.ControllerGamePlay.jump.canceled += context => Jump_Stopped();

        controls.ControllerGamePlay.walk.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.ControllerGamePlay.walk.canceled += ctx => move = Vector2.zero;

        controls.ControllerGamePlay.crouch.performed += ctx => Crouch_Perfromed();
        controls.ControllerGamePlay.crouch.canceled += ctx => Crouch_Stopped();

        controls.ControllerGamePlay.swing.performed += ctx => SwordSwing(true);
        controls.ControllerGamePlay.swing.canceled += ctx => SwordSwing(false);

        controls.ControllerGamePlay.fire.performed += ctx => FireBall(true);
        controls.ControllerGamePlay.fire.canceled += ctx => FireBall(false);


    }
    private void SwordSwing(bool swing)
    {
        animator.SetBool("swing", swing);
    }

    private void FireBall(bool shoot)
    {
        animator.SetBool("fireOne", shoot);
    }
    private void OnEnable()
    {
        controls.ControllerGamePlay.Enable();
    }

    private void Jump_performed()
    {
        jump = true;
        animator.SetBool("jumping", jump);
    }
    private void Jump_Stopped()
    {
        jump = false;
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
        Debug.Log("fire ball fired " + pos.position.ToString());
    }
}
