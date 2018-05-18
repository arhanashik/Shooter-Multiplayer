using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public GameObject bulletFab;
    public Transform bulletSpawn;
    public float bulletSpeed;

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        var x = Input.acceleration.x * 150.0f;
        var z = Input.acceleration.y * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     CmdFire();
        // }

        if (Input.touchCount>0)
        {
            CmdFire();
        }
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<Renderer>().material.color = Color.blue;
        //GetComponent<Renderer>().tag = "Hero";
    }

    [Command]
    void CmdFire()
    {
        var bullet = (GameObject)Instantiate (
            bulletFab,
            bulletSpawn.position,
            bulletSpawn.rotation);
        
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        NetworkServer.Spawn(bullet);

        Destroy(bullet, 2.0f);
    }
}