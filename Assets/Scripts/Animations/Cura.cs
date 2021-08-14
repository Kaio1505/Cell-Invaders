using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cura : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }
}
