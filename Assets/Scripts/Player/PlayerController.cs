using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;
    public float dashForce;
    public Camera sceneCamera;
    private float horizontal;
    private float vertical;
    public Vector2 mousePosition;
    public float aimAngle;
    [SerializeField] public UnityEvent OnShoot = new UnityEvent();
    public float cooldownTime;

    private bool canShoot = true;


    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        if (Input.GetMouseButton(0) && canShoot)
        {
            StartCoroutine(ShootWithCooldown());
        }
    }

    

    void FixedUpdate()
    {
        Move();
        Animate();
    }

    void Move()
    {
        rb.AddForce(moveDirection * force, ForceMode2D.Force);
    }

    IEnumerator ShootWithCooldown()
    {
        canShoot = false; // Disable shooting while the cooldown is active
        print("Peng!");
        OnShoot.Invoke();
        yield return new WaitForSeconds(cooldownTime); // Wait for the cooldown period to elapse
        canShoot = true; // Re-enable shooting
    }


    void Dash()
    {
        rb.AddForce(moveDirection * force * dashForce, ForceMode2D.Force);
    }

    void GetInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(horizontal, vertical).normalized;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 aimDirection = mousePosition - rb.position;
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        if (Input.GetKeyDown(KeyCode.Space)){
            Dash();
        }
    }

    void Animate()
    {
        bool vert = false;
        if (vertical > 0)
        {
            GetComponent<Animator>().Play("WalkUp");
            vert = true;
        }
        if (vertical < 0)
        {
            GetComponent<Animator>().Play("WalkDown");
            vert = true;
        }
        if (horizontal > 0 && !vert)
        {
            GetComponent<Animator>().Play("WalkRight");
        }
        if (horizontal < 0 && !vert)
        {
            GetComponent<Animator>().Play("WalkLeft");
        }

    }
}
