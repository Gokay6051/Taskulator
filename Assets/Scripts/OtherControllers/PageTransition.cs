using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageTransition : MonoBehaviour
{
   public void MainPage()
    {
        SceneManager.LoadScene("MainPage");
    }

   public void SignInPage()
    {
        SceneManager.LoadScene("SignInPage");
    }

   public void SignUpPage()
    {
          SceneManager.LoadScene("SignUpPage");
    }

   public void TasksPage()
    {
        SceneManager.LoadScene("TasksPage");
    }
}
