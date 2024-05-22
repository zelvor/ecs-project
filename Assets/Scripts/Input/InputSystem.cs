using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public partial class InputSystem : SystemBase
{
    private ControlECS _controlECS;
    protected override void OnCreate()
    {
        if (!SystemAPI.TryGetSingleton(out InputComponent inputComponent))
        {
            EntityManager.CreateEntity(typeof(InputComponent));
        }

        _controlECS = new ControlECS();
        _controlECS.Enable();
    }
    protected override void OnUpdate()
    {
        Vector2 moveVector = _controlECS.Player.Move.ReadValue<Vector2>();
        Vector2 mousePosition = _controlECS.Player.MousePos.ReadValue<Vector2>();
        bool shoot = _controlECS.Player.Shoot.IsPressed();
        SystemAPI.SetSingleton(new InputComponent
        {
            Movement = new float2(moveVector.x, moveVector.y),
            MousePosition = new float2(mousePosition.x, mousePosition.y),
            Shoot = shoot
        });
    }

}
