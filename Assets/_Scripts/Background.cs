using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform Ship;

    float x;

    void Update() {
        x = Ship.position.x + 23;
        transform.position = new Vector3(x, 0, 0);
    }
}
