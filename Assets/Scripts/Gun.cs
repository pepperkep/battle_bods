using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject shootPoint;

    // Update is called once per frame
    public void Fire()
    {
        Instantiate(bulletPrefab, shootPoint.transform.position, shootPoint.transform.rotation);
        JukeBox.Instance().playLaserSound();
    }
}
