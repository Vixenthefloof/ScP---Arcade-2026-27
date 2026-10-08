using UnityEngine;

public class bulletCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);

    }
}
