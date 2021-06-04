using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

[UpdateInGroup(typeof(SimulationSystemGroup))]
public class SpawnerSystem : SystemBase
{
    BeginInitializationEntityCommandBufferSystem m_EntityCommandBufferSystem;

    protected override void OnCreate()
    {
        m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().AsParallelWriter();

        Entities
            .WithName("SpawnerSystem")
            .WithBurst(FloatMode.Default, FloatPrecision.Standard, true)
            .ForEach((Unity.Entities.Entity entity, int entityInQueryIndex, in Spawner spawner, in LocalToWorld location) =>
            {
                for (int x = 0; x < spawner.Erows; x++)
                {
                    for (int z = 0; z < spawner.Ecols; z++)
                    {
                        var instance = commandBuffer.Instantiate(entityInQueryIndex, spawner.Prefab);

                        var pos = math.transform(location.Value,
                            new float3(x, noise.cnoise(new float2(x, z) * 0.21f) * 3, z));
                        commandBuffer.SetComponent(entityInQueryIndex, instance, new Translation { Value = pos });
                    }
                }

                commandBuffer.DestroyEntity(entityInQueryIndex, entity);
            }).ScheduleParallel();

        m_EntityCommandBufferSystem.AddJobHandleForProducer(Dependency);
    }
}