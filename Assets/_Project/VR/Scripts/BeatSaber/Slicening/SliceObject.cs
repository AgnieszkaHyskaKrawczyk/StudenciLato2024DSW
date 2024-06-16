using System;
using BeatSaber.Core;
using EzySlice;
using UnityEngine;

namespace BeatSaber.Slicening
{
    public class SliceObject : MonoBehaviour
    {
        [SerializeField] private Transform start;
        [SerializeField] private Transform end;
        [SerializeField] private VelocityEstimator velocityEstimator;
        [SerializeField] private Material slicedMaterial;
        [SerializeField] private LayerMask mask;
        [SerializeField] private CubeColor color;
        [SerializeField] private float force;

        private void FixedUpdate()
        {
            if (Physics.Linecast(start.position, end.position, out var hit, mask))
            {
                Slice(hit.transform.gameObject);
            }
        }

        public void Slice(GameObject target)
        {
            var velocity = velocityEstimator.GetVelocityEstimate();
            var position = end.position;
            var planeNormal = Vector3.Cross(position - start.position, velocity);
            planeNormal.Normalize();
            
            var hull = target.Slice(position, planeNormal);
            if (hull != null)
            {
                var upper = hull.CreateUpperHull(target, slicedMaterial);
                var lower = hull.CreateLowerHull(target, slicedMaterial);
                AddComponentsToSlicedObject(upper);
                AddComponentsToSlicedObject(lower);
                
                target.TryRelease(color);
            }
        }

        private void AddComponentsToSlicedObject(GameObject obj)
        {
            var rb = obj.AddComponent<Rigidbody>();
            var col = obj.AddComponent<MeshCollider>();
            col.convex = true;
            rb.AddExplosionForce(force, obj.transform.position, 1);
        }
    }
}