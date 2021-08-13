using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosao : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
            yield return new WaitForSeconds(0.6f);
            Destroy(gameObject);
    }
}
