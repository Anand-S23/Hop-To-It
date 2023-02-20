using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        Vector2 playerPos = new Vector2(3, 3);
        PhotonNetwork.Instantiate(player.name, playerPos, Quaternion.identity);
    }

}
