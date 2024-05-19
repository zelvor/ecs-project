using UnityEngine;
using Unity.Entities;

public class PlayerAuthoring : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public GameObject BulletPrefab;
    public int NumberOfBulletsToSpawn = 50;

    [Range(0f, 10f)] public float BulletSpread = 5f;

    public class PlayerBaker : Baker<PlayerAuthoring>
    {
        public override void Bake(PlayerAuthoring authoring)
        {
            Entity playerEntity = GetEntity(TransformUsageFlags.None);

            AddComponent(playerEntity, new PlayerComponent
            {
                MoveSpeed = authoring.MoveSpeed,
                BulletPrefab = GetEntity(authoring.BulletPrefab, TransformUsageFlags.None),
                NumberOfBulletsToSpawn = authoring.NumberOfBulletsToSpawn,
                BulletSpread = authoring.BulletSpread
            });
        }
    }
}
