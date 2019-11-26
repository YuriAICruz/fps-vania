using Graphene.Inventory;
using Graphene.Inventory.Wearables;
using UnityEngine;

namespace Core.Weapons
{
    public class Pistol : GunFps
    {
        public GameObject hitspot;
        
        protected override void PresentShoot(Ray ray)
        {
            base.PresentShoot(ray);
            Debug.DrawRay(ray.origin, ray.direction * gunData.maxDistance, Color.yellow, 10);
            Debug.DrawLine(tip.position, ray.GetPoint(gunData.maxDistance), Color.yellow, 10);
        }
        protected override void PresentShoot(Ray ray, RaycastHit hit)
        {
            base.PresentShoot(ray, hit);
            
            Instantiate(hitspot, hit.point, Quaternion.LookRotation(-hit.normal, Vector3.up), null);
        }
        protected override void PresentShoot(Ray ray, RaycastHit hit, IDamageble dmg)
        {
            base.PresentShoot(ray, hit, dmg);
            
            dmg.DoDamage(gunData.damage, ray.origin);
        }
    }
}

