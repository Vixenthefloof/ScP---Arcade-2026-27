using UnityEngine;

public class bulletView : MonoBehaviour
{

    public PlayerController curWeaponType;
    public Renderer normalShot;
    public Renderer buckShot;
    public Renderer heavyShot;

    // Update is called once per frame
    void Update()
    {
        if (curWeaponType.playerLives == 0)
        {
            normalShot.enabled = false;
            buckShot.enabled = false;
            heavyShot.enabled = false;
        }
        else if (curWeaponType.weaponType == 0)
        {
            normalShot.enabled = true;
            buckShot.enabled = false;
            heavyShot.enabled = false;
        }   
        else if (curWeaponType.weaponType == 1)
        {
            normalShot.enabled = false;
            buckShot.enabled = true;
            heavyShot.enabled = false;
        }
        else
        {
            normalShot.enabled = false;
            buckShot.enabled = false;
            heavyShot.enabled = true;

        }
    }
}
