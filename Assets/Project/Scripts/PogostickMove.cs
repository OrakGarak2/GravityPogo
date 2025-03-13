using UnityEngine;

public class PogostickMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float maxDistance;
    [SerializeField] float minDistance;

    [SerializeField] LayerMask targetLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetLayer = LayerMask.GetMask("Ground", "Enemy");

        minDistance = 1.1f;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void Jump()
    {
        Debug.DrawRay(transform.position, Vector2.down * maxDistance, Color.yellow);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, maxDistance, targetLayer);

        if (hit && hit.distance < minDistance)
        {
            rb.AddForce(Vector2.up * 5f);
        }

        Debug.Log($"hit.distance: {hit.distance}");
    }

    void Land()
    {

    }
}
