using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class RayHandler
    {
        public IEnumerable<Vector2> MakeRay(Vector2 origin,Vector2 direction,int hitsCount)
        {
            int hits = 0;
            var rayOrigin = origin;
            var rayDirection = direction.normalized;
            RaycastHit2D hit;
            while (hitsCount>hits)
            {
                hit = Physics2D.Raycast(rayOrigin +rayDirection*0.000001f, rayDirection, 30,LayerMask.GetMask("Water"));
                yield return (rayOrigin);
                if (hit.collider != null)
                {
                    rayDirection = Vector2.Reflect(rayDirection,hit.normal).normalized;
                    rayOrigin = hit.point;
                    hits++;
                }
                else
                {
                    yield return (Vector2.Reflect(rayDirection,hit.normal).normalized*30f);
                    yield break;
                }
            }
            

        }
    }
}