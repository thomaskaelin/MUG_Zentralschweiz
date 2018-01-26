using System;
using System.Collections.Generic;
using System.ComponentModel;
using MUG_App.Common;
using NUnit.Framework;

namespace MUG_App.Test.Unit
{
    [TestFixture]
    public abstract class ViewModelFixtureBase<TTestee>
        where TTestee : ViewModelBase
    {
        [SetUp]
        public void SetUp()
        {
            PropertyChangedEvents = new List<string>();
            IsBusyStates = new List<bool>();

            Testee = CreateTestee();
            Testee.PropertyChanged += DoOnPropertyChanged;
        }

        private void DoOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            var propertyName = propertyChangedEventArgs.PropertyName;

            PropertyChangedEvents.Add(propertyName);

            if (propertyName == nameof(Testee.IsBusy))
            {
                IsBusyStates.Add(Testee.IsBusy);
            }
        }

        protected TTestee Testee { get; private set; }

        protected List<string> PropertyChangedEvents { get; private set; }

        protected List<bool> IsBusyStates { get; private set; }

        protected abstract TTestee CreateTestee();
    }
}
