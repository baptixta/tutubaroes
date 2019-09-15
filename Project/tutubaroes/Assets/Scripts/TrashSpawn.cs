using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawn : MonoBehaviour
{
    public GameObject[] lixo;
    public float delay;
    public Transform spawnpoint;
    public Transform spawnpointCenter;

    IEnumerator Start ()
    {
        yield return new WaitForSeconds(delay);
        spawnpointCenter.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        GameObject obj = Instantiate(lixo[Random.Range(0, lixo.Length)], spawnpoint.position, Quaternion.Euler(Random.Range(0,360), Random.Range(0, 360), Random.Range(0, 360)));
        obj.transform.localScale *= 0.3f;
        StartCoroutine(Start());
    }
}
