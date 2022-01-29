using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Makes the attached button to open URL on click
/// </summary>

[RequireComponent(typeof(Button))]
public class ButtonURL : MonoBehaviour
{
    [HideInInspector] [SerializeField] private Button button;
    [SerializeField] private string url;

    public string URL { get => url; set => url = value; }
    public Button Button { get => button; }

    private void OnValidate()
    {
        this.ValidateComponent(ref button);
        Button.onClick.OnValidateOnlyAddEvent(OpenUrl);
    }

    public void OpenUrl()
    {
        Application.OpenURL(URL);
    }
}
