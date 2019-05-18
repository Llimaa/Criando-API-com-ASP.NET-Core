﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DevStore.Domain.StoreContext.ValueObjects
{
    public class Name
    {
        public Name(string fistName, string lastName)
        {
            FistName = fistName;
            LastName = lastName;
        }

        public string FistName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FistName} {LastName}";
        }
    }
}
