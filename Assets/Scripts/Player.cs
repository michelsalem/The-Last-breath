using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    [SerializeField]
    private bool  reLoadPosition = false;
    [SerializeField]
    private float speed =3f;
        private Rigidbody2D rb;
      [SerializeField]
        private Animator animator;
    private Vector2 move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        int isPositionAvalaibe =PlayerPrefs.GetInt(PlayerConstns.RESTART_POSITION_AVALAIBLE);
if (reLoadPosition && isPositionAvalaibe == 1)
        {
            gameObject.transform.position=LoadRestartPosition();
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = move * speed;
      
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("interactive"))
        {
            collision.gameObject.GetComponent<InteractiveObject>().action();
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("IsMoving",true);
        if (context.canceled)
        {
            animator.SetBool("IsMoving",false);
            animator.SetFloat("LastX",move.x);
            animator.SetFloat("LastY",move.y);

        }
      move = context.ReadValue<Vector2>();
      animator.SetFloat("inputX",move.x);
            animator.SetFloat("inputY",move.y);

    }
    private Vector2 LoadRestartPosition()
    {
        return new Vector2(
            PlayerPrefs.GetFloat(PlayerConstns.X_RESTART_POSITION), 
            PlayerPrefs.GetFloat(PlayerConstns.Y_RESTART_POSITION)
            );
    }

}
