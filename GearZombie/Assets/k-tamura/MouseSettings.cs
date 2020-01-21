using UnityEngine;

public class MouseSettings : MonoBehaviour
{
    [SerializeField]
    Texture2D MouseCorsor2D;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(MouseCorsor2D, new Vector2(0, 0), CursorMode.ForceSoftware);
    }
}
