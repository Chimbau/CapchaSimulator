using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour
{

    public Texture imagem;

    void OnGUI()
    {
        // Make a label that uses the "box" GUIStyle.
        GUI.Toggle(new Rect(400, 400, 100, 200), false,imagem, "Button");
        GUI.Toggle(new Rect(0, 0, 100, 200), false, imagem, "Button");

        // Make a button that uses the "toggle" GUIStyle



    }


}