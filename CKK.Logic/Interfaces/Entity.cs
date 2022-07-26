using System;
using CKK.Logic.Models;
using CKK.Logic.Exceptions;


namespace CKK.Logic.Interfaces
{
    [Serializable]
    public abstract class Entity : Object
    {
      
        public string Name { get; set; }


    }
}
