﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacto.Data;
using System.ComponentModel;
using System.Collections.ObjectModel;
namespace Contacto.Model
{
    //This class is used to create a contact object to be added to the contact list.
    public class Contact : INotifyPropertyChanged
    {
        private string _uniqueContactID;
        public string uniqueContactID
        {
            get { return _uniqueContactID; }
            set { _uniqueContactID = value; }
        }
        private string firstName;
        public string mufirstName
        {
            get { return firstName; }
            set
            {
                if (value != firstName)
                {
                    firstName = value;
                    NotifyPropertyChanged("firstName");
                }
            }
        }


        private string primary_contact_num;
        public string muprimary_contact_num
        {

            get { return primary_contact_num; }
            set {
                if (value != primary_contact_num){
                
                    primary_contact_num = value;
                    NotifyPropertyChanged("primary_contact_num");
                
               }
            
            
            
            }
            
        }

        private string primary_email_address;
        public string muprimary_email_address
        {

            get { return primary_email_address; }
            set { primary_email_address = value;
                  NotifyPropertyChanged("primary_email_address");

            }
        }


        private string lastName;
        public string mulastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

    
        
        public class DynamicFields : INotifyPropertyChanged
        {
            public DynamicFields()
            {
                key = "";
                dValue = "";
            }
            private string key;
            public string muKey
            {
                get { return key; }
                set
                {
                    if (value != key)
                    {
                        key = value;
                        NotifyPropertyChanged("key");
                    }
                }
            }
            private string dValue;
            public string muValue
            {
                get { return dValue; }
                set
                {
                    if (value != dValue)
                    {
                        dValue = value;
                        NotifyPropertyChanged("dValue");
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(String propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (null != handler)
                    handler(this, new PropertyChangedEventArgs(propertyName));
            }

        }

        public ObservableCollection<DynamicFields> Dynamic = new ObservableCollection<DynamicFields>();
        public ObservableCollection<DynamicFields> dynamicProperty
        {
            get { return this.Dynamic; }
            set { this.Dynamic = value; }
        }

        public void deleteDuplicates()
        {
            try
            {
               for (int i = 0; i < Dynamic.Count; i++)
               {
                   for (int j = 0; j < Dynamic.Count; j++)
                   {
                       if (Dynamic.ElementAt(i).muKey == Dynamic.ElementAt(j).muKey && j != i)
                           Dynamic.RemoveAt(j);
                    }
                }
            }catch(Exception ex){
                ex.ToString();
            
            }
        }

        public void fillDynamicFields()
        {

            Dynamic.Clear();

            foreach (var temp in customFields)
            {

                DynamicFields myFields = new DynamicFields();

                myFields.muKey = temp.Key;
                myFields.muValue = temp.Value;

                Dynamic.Add(myFields);
                NotifyPropertyChanged("Dynamic");
            
            }



        }


        private Dictionary<string, string> customFields = new Dictionary<string, string>();

        public Dictionary<string, string> muCustomFields
        {

            get { return customFields; }
            set { customFields = value; }

        }


        public Contact(string uniqueID, string first, string last)
        {
            firstName = first;
            uniqueContactID = uniqueID;
            lastName = last;
            primary_contact_num = " ";
            primary_email_address = " ";
        }

        public Contact()
        {
            firstName = "test";
            lastName = "testing";
            uniqueContactID = "12";
            primary_contact_num = " ";
            primary_email_address = " ";

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}