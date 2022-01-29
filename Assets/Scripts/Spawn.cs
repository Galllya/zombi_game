using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;
    public Player player;

    private IEnumerator SpawnZombi()
    {
        if (player !=  null)
        while (!player.isDead)
        {
           
            Instantiate(enemy,transform.position, enemy.transform.rotation) ;
            yield return new WaitForSeconds(1f);
        }
        

    } 
    void Start()
    {

        player = FindObjectOfType<Player>();

        StartCoroutine(SpawnZombi());
    }




    // Update is called once per frame
    void Update()
    {
    
    }
}
