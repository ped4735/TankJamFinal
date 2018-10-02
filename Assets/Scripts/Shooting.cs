using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    [SerializeField]private GameObject muzzle;
    [SerializeField] private CommandController cmd;
    
    private bool isReloading;


    public void Shoot()
    {

        //PLACEHOLDER: Verify is reloading on the command, not here in here
        if (!isReloading)
        {
            RaycastHit2D hit = Physics2D.Raycast(muzzle.transform.position, muzzle.transform.up, 10);
            Debug.DrawRay(muzzle.transform.position, muzzle.transform.up * 10, Color.blue,1f);

            if (hit)
            {
                GameObject hitObject = hit.collider.gameObject;
                Debug.Log("Hit something: "+ hitObject);
            }
            cmd.ReceiveCommand("SHOOT\n");
            StartCoroutine(ReloadCoroutine());
        }
        else
        {
            Debug.Log("I am reloading!!");
            cmd.ReceiveCommand("I am reloading!!\n");
        }

     }
    

    IEnumerator ReloadCoroutine()
    {
        isReloading = true;
        yield return new WaitForSeconds(2f);
        isReloading = false;
       
    }
}
