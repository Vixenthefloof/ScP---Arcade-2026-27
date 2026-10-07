using UnityEngine;

public class bulletCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

    }
}
