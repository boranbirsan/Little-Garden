using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenlingAI : MonoBehaviour
{
    public float maxSteerForce = 5f;
    public float speed = 3.5f;

    [Range(0, 1)]
    public float extrovertedness;
    [Range(0, 1)]
    public float laziness;

    private bool facingRight = true;
    private bool moving = true;
    private float moveTime = 0f;
    private float restTime = 0f;
    private float elapsedTime = 0f;

    private Vector2 direction;
    private Vector2 velocity;
    private Vector2 acceleration;

    public GameObject FOV;
    public GameObject Ranch;
    private FieldofView view;
    private Transform fov_transform;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fov_transform = FOV.transform;

        anim = GetComponent<Animator>();

        view = (FieldofView)FOV.GetComponent(typeof(FieldofView));
    }

    void FixedUpdate()
    {
        acceleration = Vector2.zero;

        if (elapsedTime < moveTime && moving)
        {
            velocity = view.FindPath() * speed;

            Vector2 ranchCenterOffset = (Ranch.transform.position - transform.position);
            Vector2 centerForce = SteerTowards(ranchCenterOffset) * extrovertedness;

            acceleration += centerForce;

            elapsedTime += Time.deltaTime;
        }
        else if (elapsedTime >= moveTime && moving)
        {
            moving = false;
            velocity = Vector2.zero;
            restTime = Random.Range(2f, 4f);
            elapsedTime = 0f;
        }
        else if (elapsedTime < restTime && !moving)
        {
            elapsedTime += Time.deltaTime;
        }
        else if (elapsedTime >= restTime && !moving)
        {
            moving = true;
            direction.x = Random.Range(-3f, 3f);
            direction.y = Random.Range(-3f, 3f);
            moveTime = Random.Range(2f, 4f);

            velocity = direction.normalized * speed;

            view.ChangeDirection(velocity);
            elapsedTime = 0f;
        }

        velocity += acceleration * Time.deltaTime;

        if ((velocity.x < -0.01f && facingRight) || (velocity.x > 0.01f && !facingRight)) Flip();

        anim.SetBool("facingRight", facingRight);
        anim.SetFloat("Horizontal", velocity.x);
        rb.MovePosition((Vector2)transform.position + velocity * Time.deltaTime);
        view.ChangeDirection(velocity);
    }

    public Vector2 SteerTowards(Vector2 vector)
    {
        Vector2 v = vector.normalized * speed - velocity;
        return Vector2.ClampMagnitude(v, maxSteerForce);
    }

    public void Flip()
    {
        facingRight = !facingRight;
    }
}
