using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;

    public Vector3 position;

    private void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, position, Quaternion.identity);
    }
}
