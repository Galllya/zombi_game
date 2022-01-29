using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    Player player;
    Vector3 offset;
    void Start()
    {
        player = FindObjectOfType<Player>();
        offset = transform.localPosition;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
