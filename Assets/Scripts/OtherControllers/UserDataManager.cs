using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : MonoBehaviour
{
    public UserModel userModel;

    private static UserDataManager instance;
    public static UserDataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UserDataManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "UserDataManager";
                    instance = obj.AddComponent<UserDataManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
