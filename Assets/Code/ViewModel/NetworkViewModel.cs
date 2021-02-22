using Code.View;
using Mirror;
using UnityEngine;


namespace Code.ViewModel
{
    public class NetworkViewModel
    {
        private GridSpaceView[] _gridSpaces;

        public NetworkViewModel(GridSpaceView[] gridSpaces)
        {
            _gridSpaces = gridSpaces;
        }
        public void OnClientConnect(NetworkConnection conn)
        {

        }
        
        public void OnServerAddPlayer(NetworkConnection conn)
        {
            Debug.Log($"{conn} has just connected! There are");
            foreach (var gridSpace in _gridSpaces)
            {
                gridSpace.NetworkIdentity.AssignClientAuthority(conn);
            }
        }
    }
}