﻿using SecurityDoors.BL.Models;
using System;
using System.Collections.Generic;

namespace SecurityDoors.UI.View
{
    struct Action
    {
        public int number { get; }
        public List<Person> persons { get; }

        public Action(int number, List<Person> persons)
        {
            this.number = number;
            this.persons = persons ?? throw new ArgumentNullException(nameof(persons));
        }
    }
}
