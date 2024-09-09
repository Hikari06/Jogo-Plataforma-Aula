using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    private float horizontal;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    public Animator animator;

    // Start is called before the first frame update
    private void Awake()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Debug.Log(horizontal);
        this.rb.velocity = new Vector2(horizontal * 8, rb.velocity.y);

            
            animator.SetFloat("speed", Mathf.Abs(horizontal));
            if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        }

            Flip();

            /*f (Input.GetKey(KeyCode.Space))
             {
                 Debug.Log("Apertou o espa�o");
             }
             if (Input.GetMouseButtonDown(1)) {
                 Debug.Log("Clicou com io botao direito");
             }  */

        }

        private void Flip()
        {
            if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }
    }
