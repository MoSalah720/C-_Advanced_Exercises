using Delegate_Exercise3;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate_Exercise_3
{
    internal class Broker
    {

        // Create Dictionary to hold Subjects and Subscribers

        private Dictionary<string, List<Action<TempArgs>>> _SubscribersList = new();

        
         //* Dev1 -(Mohamed , Ali, Omar ,Ibrahim)
         //* Dev2 -(Mahmoud , Nada , Khaled, Salah)
         //* 
         //* TempChanged (Alarm , Display)
         //* 


        public void Subscibe(string Subject , Action<TempArgs> Action)
        {
            // Adding Action handler to subsciber list
            // before accessing the key in dictionary ensure it exists

            if (!_SubscribersList.ContainsKey(Subject))
            {
                _SubscribersList[Subject] = new List<Action<TempArgs>>(); 
            }
            _SubscribersList[Subject].Add(Action);
        }
         
        public void Publish(string Subject , TempArgs message)
        {
            if (_SubscribersList.ContainsKey(Subject))
            {
                List<Action<TempArgs>> SubscribersToSubject = _SubscribersList[Subject];

                foreach (var item in SubscribersToSubject)
                {
                    item.Invoke(message);
                }
            }
        }
    }
}
