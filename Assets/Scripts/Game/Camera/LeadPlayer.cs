using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadPlayer : MonoBehaviour
{
    [SerializeField]GameObject player;
    float dist;
    // Start is called before the first frame update
    void Start()
    {
        dist = this.transform.position.y - player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y - player.transform.position.y < dist)
        {
            this.transform.position = new Vector3(0, player.transform.position.y + dist, -10);
        }
    }
}
