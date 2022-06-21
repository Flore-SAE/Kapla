using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera mainCamera;
    private Move2D move2D;
    private Vector3 mousePosition;
    private Spawner spawner;
    private GameModeManager gameModeManager;
    private Rotate2D rotate2D;
    private KaplaResizer kaplaResizer;
    private KaplaRemover kaplaRemover;

    private void Awake()
    {
        mainCamera = Camera.main;
        move2D = GetComponent<Move2D>();
        spawner = GetComponent<Spawner>();
        gameModeManager = GetComponent<GameModeManager>();
        rotate2D = GetComponent<Rotate2D>();
        kaplaResizer = GetComponent<KaplaResizer>();
        kaplaRemover = GetComponent<KaplaRemover>();
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
            spawner.Spawn(transform);
    }

    public void OnSwitchMode(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            gameModeManager.Switch();
    }

    public void OnRotate(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
            return;
        var inputValue = ctx.ReadValue<float>();
        rotate2D.ActivateRotation(inputValue);
    }

    public void OnSwitchSide(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            kaplaResizer.SwitchSides();
    }

    public void OnRemove(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            kaplaRemover.Remove(mousePosition);
    }

    public void OnShootCanon(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
            FindObjectOfType<Canon>().Shoot();
    }

    public void OnRotateCanon(InputAction.CallbackContext ctx)
    {
       if(ctx.started)
           return;
       FindObjectOfType<Canon>().GetComponent<Rotate2D>().ActivateRotation(ctx.ReadValue<float>());
    }
}
