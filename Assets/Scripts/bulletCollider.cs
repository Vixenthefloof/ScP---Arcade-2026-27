using UnityEngine;

public class bulletCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag != "player")
        {
            Destroy(gameObject);
        }
    }
}
