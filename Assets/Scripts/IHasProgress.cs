using System;
using UnityEngine;

public interface IHasProgress 
{
    public event EventHandler<OnProgressChangedEventArgs> OnProgress ;
    public class OnProgressChangedEventArgs : EventArgs
    {
        public float cuttingProgressNormalized;
    }
}
