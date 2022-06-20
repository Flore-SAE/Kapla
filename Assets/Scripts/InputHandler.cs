using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera mainCamera;
    private Move2D move2D;
    private Vector3 mousePosition;

    private void Awake()
    {
        mainCamera = Camera.main;
        move2D = GetComponent<Move2D>();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        mousePosition = ctx.ReadValue<Vector2>();
        mousePosition.z = Mathf.Abs(mainCamera.transform.position.z);
        var worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        move2D.TeleportTo(worldPosition);
    }

    public void OnPlace(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            GetComponent<Spawner>().Spawn(transform);
        }
    }

    public void OnSwitchMode(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            GetComponent<GameModeManager>().Switch();
    }

    public void OnRotate(InputAction.CallbackContext ctx)
    {
        GetComponent<Rotate2D>().SetRotationSpeed(ctx.ReadValue<float>());
    }

    public void OnSwitchSide(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            GetComponent<KaplaResizer>().SwitchSides();
    }

    public void OnRemove(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            GetComponent<KaplaRemover>().Remove(mousePosition);
    }
}
