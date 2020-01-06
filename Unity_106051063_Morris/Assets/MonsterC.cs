using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterC : MonoBehaviour
{
    #region 數據
    [Header("速度"), Range(50, 2000)]
    public float speed;
    [Header("旋轉"), Range(50, 200)]
    public float turn;
    public Rigidbody rig;
    public Transform Tra;
    public Animator ani;
    public Rigidbody rigcatch;

    #endregion

    private void Update()
    {
        Walk();
        Rota();
        Attack();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "!!!!!" && ani.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());
            other.GetComponent<HingeJoint>().connectedBody = rigcatch;
        }
        if (other.name == "area" && ani.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            GameObject.Find("!!!!!").GetComponent<HingeJoint>().connectedBody = null;
        }

    }

    #region 行動

    void Walk()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Attack")) return;
        float v = Input.GetAxis("Vertical");
        rig.AddForce(Tra.forward * v * speed * Time.deltaTime);
        ani.SetBool("run", v != 0);
    }
    void Rota()
    {
        float h = Input.GetAxis("Horizontal");
        Tra.Rotate(0, turn * h * Time.deltaTime, 0);

    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ani.SetTrigger("attack");
        }

    }

    #endregion
}