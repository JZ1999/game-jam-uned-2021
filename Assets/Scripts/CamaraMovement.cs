using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CamaraMovement : MonoBehaviour
{
    public GameObject player;
    private Vector3 diff;
    private Vector3 pastPosition;
    public GameSetupController collectorPlayers;

    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) {
            foreach (GameObject p in collectorPlayers.players.Values)
            {
                if (p.GetComponent<PhotonView>().isMine)
                {
                    player = p;
                }
            }
			if (player == null) return;
            pastPosition = player.transform.position;
            return; }

        diff = player.transform.position - pastPosition;
        pastPosition = player.transform.position;
        transform.position += diff.normalized * 0.08f;
       
    }
}
