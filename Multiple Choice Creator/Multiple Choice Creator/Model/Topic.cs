﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Choice_Creator.Model
{
    public class Topic
    {
        private string name;
        private string description;
        private int parent;

        public Topic(string name,string description,int parent)
        {
            this.name = name;
            this.description = description;
            this.parent = parent;     
        }

        public string getName()
        {
            return this.name;
        }

        public string getDescription()
        {
            return this.description;
        }

        public int getParent()
        {
            return this.parent;
        }
    }
}