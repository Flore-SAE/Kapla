using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    public enum Mode
    {
        Simulated,
        Static
    }

    public Mode defaultMode;

    public Transform kaplasParent;

    private Mode currentMode;

    private void Start()
    {
        currentMode = defaultMode;
    }

    public void Switch()
    {
        currentMode = currentMode switch
        {
            Mode.Simulated => Mode.Static,
            Mode.Static => Mode.Simulated,
            _ => defaultMode
        };

        SwitchRigidbodies();
        GetComponent<Spawner>().enabled = currentMode == Mode.Static;
        GetComponent<SpriteRenderer>().enabled = currentMode == Mode.Static;
    }

    private void SwitchRigidbodies()
    {
        var kaplasRB = kaplasParent.GetComponentsInChildren<Rigidbody2D>();
        foreach (var kapla in kaplasRB)
        {
            switch (currentMode)
            {
                case Mode.Simulated:
                    kapla.bodyType = RigidbodyType2D.Dynamic;
                    break;
                case Mode.Static:
                    kapla.bodyType = RigidbodyType2D.Static;
                    break;
                default:
                    Debug.LogError("Unexpected state when switching rigidbodies’ values");
                    break;
            }
        }
    }
}
