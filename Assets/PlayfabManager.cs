using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class PlayfabManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    public GameObject rowPrefab;
    public Transform rowsParent;
    public Text message;
    public InputField email;
    public InputField password;
    public InputField username;
    public GameObject emailInput;
    public GameObject passwordInput;
    public GameObject loginButton;
    public GameObject registerButton;
    public GameObject usernameInput;
    public GameObject submitUsername;
    public void Register(){

        if(password.text.Length < 6){
            message.text = "Password too short!";
            return;
        }

        var request = new RegisterPlayFabUserRequest {
            Email = email.text,
            Password = password.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result){
        message.text = "Account Registered Successfully!";
    }


    public void Forgot(){

    }

    public void Login(){
        var request = new LoginWithEmailAddressRequest {
            Email = email.text,
            Password = password.text,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams{
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnSuccess, OnError);
    }


    // void Login(){
    //     var request = new LoginWithCustomIDRequest{
    //         CustomId = SystemInfo.deviceUniqueIdentifier,
    //         CreateAccount = true
    //     };
    //     PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    // }

    void OnSuccess(LoginResult result){

        string name = null;
        if(result.InfoResultPayload.PlayerProfile != null){
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
            NameController.usernamee = name;
        }

        if(name == null){
            message.text = "Account Requires Username";
            emailInput.SetActive(false);
            passwordInput.SetActive(false);
            loginButton.SetActive(false);
            registerButton.SetActive(false);
            usernameInput.SetActive(true);
            submitUsername.SetActive(true);
        }
        else{
            SceneManager.LoadScene("MainMenu");
        }

        Debug.Log("Successful Login/Account Created!");
    }

    public void SubmitUsernameButton(){
        var request = new UpdateUserTitleDisplayNameRequest{
            DisplayName = username.text,
        };
        NameController.usernamee = username.text;
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result){
        Debug.Log("Username Added!");
        SceneManager.LoadScene("MainMenu");
    }

    void OnError(PlayFabError error){
        Debug.Log("Error While Logging In/Creating Account!");
        Debug.Log(error.GenerateErrorReport());
        message.text = error.ErrorMessage;
    }

    public void SendLeaderboard(int score){
        var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate {
                    StatisticName = "Leaderboard",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result){
        Debug.Log("Successfully Sent to Leaderboard!");
    }

    public void GetLeaderboard(){
        var request = new GetLeaderboardRequest {
            StatisticName = "Leaderboard",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result){

        foreach(Transform item in rowsParent){
            Destroy(item.gameObject);
        }

        foreach(var item in result.Leaderboard){
            
            GameObject go = Instantiate(rowPrefab, rowsParent);

            Text[] texts = go.GetComponentsInChildren<Text>();

            texts[0].text = (item.Position+1).ToString();
            
            if(item.DisplayName == null){
                texts[1].text = item.PlayFabId;
            }
            else{
                texts[1].text = item.DisplayName;
            }
            texts[2].text = item.StatValue.ToString();

            Debug.Log("HERE:" + item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }
}
