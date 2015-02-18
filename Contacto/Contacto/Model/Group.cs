﻿using System;
using Contacto;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacto.Model
{
    //This class is used to create a group made up of select contacts from the contact list. 
    //contacts should be able to be a member of many groups. 
    class Group
    {
        private int uniqueGroupID;
        public int muGroup{ 
        get {return uniqueGroupID;}
        set { uniqueGroupID = value; }
        }
        private string groupName;
        public string myGroupName{
        get { return groupName; }
        set { groupName = value; }
        }

        private string groupType;
        public string muGroupType
        {
            get { return groupType; }
            set { groupType = value; }
        }
        private ObservableCollection<Contact> myGroup = new ObservableCollection<Contact>();

    }
}
