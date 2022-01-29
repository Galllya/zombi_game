using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HelthValue : MonoBehaviour
{
    public Text health;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
       player = FindObjectOfType<Player>();
        health.text = $"Çהמנמגüו: {player.curentHealth}";
    }

    // Update is called once per frame
    void Update()
    {
        health.text = $"Çהמנמגüו: {player.curentHealth}";
        if (player != null)
        {

           if (player.isDead)
            {
                health.text = "ÂÛ ÓÌÅÐËÈ!!!";
            }
        }
    }
}
