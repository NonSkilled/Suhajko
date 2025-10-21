using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class HealthHeartManager : MonoBehaviour
{
    public GameObject heartPrefab;
    public PlayerHealth playerHealth;
    List<Hearts> hearts = new List<Hearts>();

    private void Update()
    {
        DrawHearts();
    }


    public void DrawHearts()
    {
        ClearHearts();

        switch (playerHealth.health)
        {
            case 3:
                CreateFullHeart();
                CreateFullHeart();
                CreateFullHeart();
                break;
            case 2:
                CreateFullHeart();
                CreateFullHeart();
                CreateEmptyHeart();
                break;
            case 1:
                CreateFullHeart();
                CreateEmptyHeart();
                CreateEmptyHeart();
                break;
        }

        
    }

    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        Hearts heartComponent = newHeart.GetComponent<Hearts>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
    }
    public void CreateFullHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        Hearts heartComponent = newHeart.GetComponent<Hearts>();
        heartComponent.SetHeartImage(HeartStatus.Full);
    }



    public void ClearHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<Hearts>();

    }
}
