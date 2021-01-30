using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanShoot : MonoBehaviour
{
    public bool cShoot;
    // Start is called before the first frame update
    void Start()
    {
        cShoot = GetComponentInParent<Shoot>().canShoot;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cShoot = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            cShoot = false;
        }
    }
}
