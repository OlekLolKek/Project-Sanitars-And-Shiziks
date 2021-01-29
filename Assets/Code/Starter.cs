using System;
using Code.Model;
using Code.View;
using UnityEngine;


namespace Code
{
    public class Starter : MonoBehaviour
    {
        private void Start()
        {
            var gridSpacesModel = new GridSpacesModel();
            gridSpacesModel.GridSpaces = FindObjectsOfType<GridSpace>();
    }
}