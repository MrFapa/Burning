using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchDrop : MonoBehaviour
{
    [SerializeField] GameObject branch;
    [SerializeField] float length;
    [Range(0f, 1f)][SerializeField] float frequency;

    void FixedUpdate()
    {
        if ((int) Random.Range(0, 256 * (1 - this.frequency)) == 0)
        {
            GameObject tmp = Instantiate(branch);
            tmp.transform.position = new Vector2(this.transform.position.x + this.length * Random.Range(-0.5f, 0.5f), this.transform.position.y);
        }
    }
}
