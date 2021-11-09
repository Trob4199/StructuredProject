using System;
using CKK.Logic.Models;


namespace CKK.Logic.Interfaces
{
    public abstract class Entity : Object
    {
        public int id { get; set; }
        public string Name { get; set; }

    }
}
