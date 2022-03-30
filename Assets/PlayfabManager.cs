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

    public Text message;
    public InputField email;
    public InputField password;

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
        message.text = "Registered and Logged In!";
    }


    public void Forgot(){

    }

    public void Login(){
        var request = new LoginWithEmailAddressRequest {
            Email = email.text,
            Password = password.text
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
        message.text = "Logging in";
        SceneManager.LoadScene("MainMenu");

        Debug.Log("Successful Login/Account Created!");
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
        foreach(var item in result.Leaderboard){
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }
}
