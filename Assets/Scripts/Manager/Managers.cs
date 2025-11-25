using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;

public class Managers : MonoBehaviour
//PlayFab Manager
{
    [Header("Login")]
    [SerializeField] private TMP_InputField LoginEmail;
    [SerializeField] private TMP_InputField loginPassword;

    [Header("Create Account")]
    [SerializeField] private TMP_InputField Ca_Username;
    [SerializeField] private TMP_InputField Ca_Email;
    [SerializeField] private TMP_InputField Ca_Password;
    [SerializeField] private TMP_InputField Ca_ConfirmedPassword;
    [SerializeField] private TMP_InputField Ca_AvatarUrl;

    void Start()
    {
        if (PlayFabSettings.DeveloperSecretKey == null)
        {
            PlayFabSettings.DeveloperSecretKey = "Y5IW8KNPS8GYBWZSA1HDWR3TZRTK8A7PCIXF7HAA5GQQJHIU44";
        }

        if (PlayFabSettings.TitleId == null)
        {
            PlayFabSettings.TitleId = "1DA25";
        }
    }

    public void CreateAccount()
    {


        if (Ca_Password.text != Ca_ConfirmedPassword.text)
        {
            Debug.Log("Password is different");
        }

        else
        {
            RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest
            {
                Email = Ca_Email.text,
                Username = Ca_Username.text.ToLower(),
                DisplayName = Ca_Username.text,
                Password = Ca_Password.text,

            };

            PlayFabClientAPI.RegisterPlayFabUser(request, OnCreateAccountSuccess, OnCreateAccountError);

        }

       
    }

    public void OnCreateAccountSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("");
    }

    public void OnCreateAccountError(PlayFabError error)
    {
        Debug.LogError(error);
    }

    public void LogInAccount()
    {
        LoginWithEmailAddressRequest request = new LoginWithEmailAddressRequest
        {
            Email = LoginEmail.text,
            Password = loginPassword.text,
        };

        PlayFabClientAPI.LoginWithEmailAddress(request,OnLogInSuccess,OnLoginError);
    }


    public void OnLogInSuccess(LoginResult result)
    {
        Debug.Log("Inicio de sesion exitoso");
    }

    public void OnLoginError(PlayFabError error)
    {
        Debug.Log(error);
    }
}
