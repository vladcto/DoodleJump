using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject camera;
    GameObject _copyThis;
    GameObject newBarier;
    // Start is called before the first frame update
    void Start()
    {
        _copyThis = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (camera.transform.position.y - this.transform.position.y > 15)
        {
            Destroy(this.gameObject);
        }
        else if (camera.transform.position.y - this.transform.position.y > 5)
        {
            if (newBarier == null)
            {
                newBarier = Instantiate(_copyThis) as GameObject;
                newBarier.gameObject.name = "Barier";
                newBarier.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 20);
            }
        }
    }
}
