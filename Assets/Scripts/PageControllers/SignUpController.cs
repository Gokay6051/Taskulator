using UnityEngine;
using UnityEngine.UI;

public class SignUpController : MonoBehaviour
{
    public InputField IdInput;
    public InputField passwordInput;
    public Text resultText;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("SignUpButton")?.GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);      
    }

    public void OnButtonClick()
    {
        if (IdInput == null)
        {
            IdInput = GameObject.Find("UsernameInput").GetComponent<InputField>();
        }

        if (passwordInput == null)
        {
            passwordInput = GameObject.Find("PasswordInput").GetComponent<InputField>();
        }

        if (resultText == null)
        {
            resultText = GameObject.Find("ResultText").GetComponent<Text>();
        }

        //Debug.Log(RealmController.Instance.IsRealmUserReady());
        if (RealmController.Instance.IsRealmUserReady())
        {
            //Debug.Log("kayýt butonuna girdi");
            if (RealmController.Instance.AddUserModel(IdInput.text, passwordInput.text) == true)
            {
                resultText.text = "Kayýt baþarýlý";
            }
            else
            {
                resultText.text = "Bu ID baþkasýna ait";
            }
        }
        
    }
}
