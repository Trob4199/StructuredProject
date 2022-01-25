using System;
using CKK.Logic.Models;
using CKK.Logic.Exceptions;


namespace CKK.Logic.Interfaces
{
    public abstract class Entity : Object
    {
        private int ID;
        public int Id
        {
            get
            {
                return ID;
            }
            set
            {
                if(value < 0)
                {
                    throw new InvalidIdException("Id must be greater than 0");
                }
                ID = value;
            }
        }

        public void SetId(int ID)
        {
            
            if (ID < 0)
            {
                
            }
            else
            {
                Id = ID;
            }
        }

        

 
        public string Name { get; set; }


    }
}
