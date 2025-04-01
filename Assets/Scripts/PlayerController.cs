using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float moveSpeed = 3.0f;

    [Header("Components")]
    [SerializeField] private Animator playerAnim;
    [SerializeField] private Rigidbody2D playerRb;
    void Start()
    {
		if (playerAnim == null)
        {
            playerAnim = GetComponent<Animator>();
        }
        if (playerRb == null)
        {
            playerRb = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		playerAnim.SetFloat("vel", input.magnitude);

		if (input.magnitude > 0)
        {
			playerAnim.SetFloat("dirX", input.x);
            playerAnim.SetFloat("dirY", input.y);

            Vector2 newPosition = new Vector2(transform.position.x + input.x, transform.position.y + input.y);
            playerRb.MovePosition(newPosition * moveSpeed * Time.deltaTime);
		}
    }
}
