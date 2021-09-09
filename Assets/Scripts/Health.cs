using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health;
    private AnimationScript anim;
    private Animator animator;

    public float MyHealth
    {
        get => health;
        set => health = value;
    }


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<AnimationScript>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MyHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (MyHealth <= 0)
        {
            if (gameObject.tag == "Box")
            {
                animator.Play("Death");
            }

            if (gameObject.tag == "Enemy")
            {
                StartCoroutine(gameObject.GetComponent<Enemy>().Die());
            }

            if (gameObject.tag == "Player")
            {
                StartCoroutine(gameObject.GetComponent<Player>().Die());
            }
        }
    }
}