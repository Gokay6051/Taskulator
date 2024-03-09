using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignInController : MonoBehaviour
{
    public InputField IdInput;
    public InputField PasswordInput;
    public Button button;
    public Text resultText;

    void Start()
    {
        button = GameObject.Find("SignInButton")?.GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        if(IdInput == null)
        {
            IdInput = GameObject.Find("IdEditText")?.GetComponent<InputField>();
        }

        if(PasswordInput == null)
        {
            PasswordInput = GameObject.Find("PasswordEditText")?.GetComponent<InputField>();
        }

        if(resultText == null)
        {
            resultText = GameObject.Find("ResultText")?.GetComponent<Text>();
        }


        if (RealmController.Instance.IsRealmUserReady())
        {
            if (RealmController.Instance.isUser(IdInput.text, PasswordInput.text) == 2)
            {
                UserDataManager.Instance.userModel = RealmController.Instance.GetRealmUser().All<UserModel>().FirstOrDefault(d => d.UserId == IdInput.text);
                SceneManager.LoadScene("TasksPage");
            }
            else if (RealmController.Instance.isUser(IdInput.text, PasswordInput.text) == 1)
            {
                resultText.text = "Þifre hatalý";
            }
            else
            {
                resultText.text = "Kullanýcý bulunamadý";
            }
        }
    }
}
