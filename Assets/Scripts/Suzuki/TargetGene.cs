using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetGene : MonoBehaviour
{
    private Vector3 targetpos;
    public Text Scoretext;
    public static int score = 0;

    private void OnCollisionEnter(Collision collision)
    {

        score += 10;
        Scoretext.text = string.Format("Score:{0}", score);

        GetComponent<ParticleSystem>().Play();
    }
    public static int getscore()
    {
        return score;
    }
    // Start is called before the first frame update
    void Start()
    {
        targetpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
