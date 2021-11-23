using UnityEngine;

namespace DefaultNamespace
{
    public class Character : MonoBehaviour
    {
        public void Move(Vector3 dif)
        {
            transform.position += dif * Time.deltaTime;
        }

        public void LookOn(Vector3 target)
        {
            var diff = target - transform.position;
            transform.rotation = Quaternion.Euler(0,0,Mathf.Atan2(diff.y,diff.x)*Mathf.Rad2Deg);
        }
    }
}