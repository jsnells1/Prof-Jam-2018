using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform foot;
    // Start is called before the first frame update
    void Start()
    {
        foot = gameObject.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.LeftFoot);
    }

    // Update is called once per frame
    void Update()
    {
        foot.Rotate(Vector3.down * Time.deltaTime * 20);
    }
}
