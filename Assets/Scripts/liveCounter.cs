using NUnit.Framework.Internal;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class liveCounter : MonoBehaviour
{

    public PlayerController liveCount;
    public TextMeshProUGUI liveText;

    // Update is called once per frame
    void Update()
    {
        if (liveCount.playerLives == 0)
        {
            liveText.text = " ";
        }
        else if (liveCount.playerLives == 1)
        {
            liveText.text = "X";
        } 
        else if (liveCount.playerLives == 2)
        {
            liveText.text = "XX";
        }
        else
        {
            liveText.text = "XXX";
        }
    }
}
