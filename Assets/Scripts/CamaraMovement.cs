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
            int index = 1;
            foreach (GameObject p in collectorPlayers.players.Values)
            {
                Debug.Log(p.GetComponent<PhotonView>().isMine);
                Debug.Log(p.GetComponent<PhotonView>().OwnerActorNr);
                if (p.GetComponent<PhotonView>().isMine)
                {
                    player = p;
                }
                p.gameObject.tag = "Team" + index%2;
                index++;
            }

            pastPosition = player.transform.position;
        }

        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z-17);
       
    }
}
