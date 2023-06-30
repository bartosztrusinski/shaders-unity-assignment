using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private float timer = 1;
    public float repeatRate = 2;
    public float height = 2;
    public GameObject coin;

    // Update is called once per frame
    void Update()
    {
        if (timer > repeatRate)
        {
            timer = 0;
            SpawnCoin();
        }

        timer += Time.deltaTime;
    }

    private void SpawnCoin()
    {
        GameObject newCoin = Instantiate(coin);
        newCoin.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
        Destroy(newCoin, 10f);
    }
}
