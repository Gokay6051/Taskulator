using UnityEngine;
using System.Linq;  
using Realms;
using Realms.Sync;
using MongoDB.Bson;
using UnityEngine.Events;

public class RealmController : MonoBehaviour
{
    static public RealmController Instance; //Singleton, tek bir obje

    private Realm realmUser;
    private Realm realmTask;
    private App _realmApp;
    private User _realmUser;

    [SerializeField] private string _realmAppId = "taskulator4-lyimw"; //SerilazedField inspector panelinde görünmesini saðlýyor
    public UnityEvent onLogIn;


    private void Awake() //OnCreate
    {
        DontDestroyOnLoad(gameObject);
        LogInAuto();
    }

    public async System.Threading.Tasks.Task<string> LogIn()
    {
        Instance = this;

        if(realmUser == null || realmTask == null)
        {

            _realmApp = App.Create(new AppConfiguration(_realmAppId));
            if(_realmApp.CurrentUser == null)
            {
                _realmUser = await _realmApp.LogInAsync(Credentials.Anonymous());

                realmUser = await Realm.GetInstanceAsync(new PartitionSyncConfiguration("User", _realmUser));
                realmTask = await Realm.GetInstanceAsync(new PartitionSyncConfiguration("Task", _realmUser));
            }
            else
            {
                _realmUser = _realmApp.CurrentUser;
                
                realmUser = Realm.GetInstance(new PartitionSyncConfiguration("User", _realmUser)); //singleton
                realmTask = Realm.GetInstance(new PartitionSyncConfiguration("Task", _realmUser)); //singleton
            }
            
        }
        return _realmUser.Id;
    }

    public async void LogInAuto()
    {
        if(await LogIn() != "")
        {
            onLogIn?.Invoke();
        }
    }

    void OnDisable() //onPause, eriþilebilir olmadýðýnda çalýþan fonksiyon, _realm'i serbest býrakýyor
    {
        if(realmUser != null)
        {
            realmUser.Dispose();
        }

        if (realmTask != null)
        {
            realmTask.Dispose();
        }
    }

    public bool AddUserModel(string UserId, string Password) //sign up kýsmý için DB'ye id ve þifre ekliyor
    {
        if (isUser(UserId, Password) == 1 || isUser(UserId, Password) == 2) 
        {
            return false;
        }
        else
        {
            realmUser.Write(() =>
            {
                    UserModel newUser = new UserModel()
                    {
                        Id = ObjectId.GenerateNewId(),
                        _Id = _realmUser.Id,
                        UserId = UserId,
                        Password = Password,
                        Type = "User"
                    };

                    realmUser.Add(newUser);
                
            });
            return true;
        }
    }

    public void AddTaskModel(string TaskMain, string TaskTitle, string UserId)
    {
        realmTask.Write(() =>
        {
            TaskModel newTask = new TaskModel()
            {
                Id = ObjectId.GenerateNewId(),
                _Id = _realmUser.Id,
                UserId = UserId,
                TaskTitle = TaskTitle,
                TaskMain = TaskMain,
                Type = "Task"
            };
            realmTask.Add(newTask);
        }); 
    }

    public bool IsRealmUserReady()
    {
        return realmUser != null;
    }

    public bool IsRealmTaskReady()
    {
        return realmTask != null;
    }

    public int isUser(string UserId, string Password) //0=kullanýcý yok, 1=kullanýcý var, 2= þifre doðru
    {
        UserModel anUser = realmUser.All<UserModel>().FirstOrDefault(d => d.UserId == UserId);
        if (anUser != null)
        {
            if (anUser.Password == Password)
            {
                return 2;
            }
            return 1;
        }
        return 0;
    }

    public Realm GetRealmUser()
    {
        return realmUser;
    }

    public Realm GetRealmTask()
    {
        return realmTask;
    }
}
