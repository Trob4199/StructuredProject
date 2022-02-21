using System;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    [Serializable]
    public class Customer : Entity
    {
        //private int Id;
        //private string Name;
        public string Address { get; set; }

    }
}
