using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{

    public GameObject player;
    public List<GameObject> levels;

    public void Load()
    {

        levels.ForEach(x =>
        {
            Instantiate(x, new Vector3(levels.IndexOf(x) * 30, 0, 0), Quaternion.identity);
        });
        //Instantiate(camera, new Vector3(0, 2, -4.05f), new Quaternion(20, 0, 0, 0));
        Instantiate(player, new Vector3(0, 0.4f, 0), Quaternion.identity);
    }
}
