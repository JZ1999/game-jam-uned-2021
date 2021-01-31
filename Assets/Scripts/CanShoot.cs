using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanShoot : MonoBehaviour
{
    public string enemyTag;
    
    // Start is called before the first frame update
    void Start()

    {


        
        
    }
    private void Update()
    {
        if(enemyTag == "")
        {
            if(transform.parent.tag == "Team0") {
                enemyTag = "Team1";
            }else if(transform.parent.tag == "Team1")
            {
                enemyTag = "Team0";
            }
            
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == enemyTag)
        {
            GetComponentInParent<Shoot>().canShoot = true;
            GetComponentInParent<Shoot>().enemy = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.tag == enemyTag)
        {
            GetComponentInParent<Shoot>().enemy = null;
            GetComponentInParent<Shoot>().canShoot = false;
        }
    }
}
