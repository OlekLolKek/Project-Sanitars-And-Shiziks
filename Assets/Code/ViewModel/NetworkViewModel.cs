using Mirror;
using UnityEngine;


namespace Code.ViewModel
{
    public class NetworkViewModel
    {
        public void OnClientConnect(NetworkConnection conn)
        {
            Debug.Log("I connected to a server!");
        }

        public void OnServerAddPlayer(NetworkConnection conn)
        {
            Debug.Log($"{conn} has just connected! There are");
        }
    }
}