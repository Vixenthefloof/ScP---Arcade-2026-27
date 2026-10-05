using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class stopCollisionsBG : MonoBehaviour
{
    public string StuckObjectTag = "stopCollider";

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(StuckObjectTag))
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}

