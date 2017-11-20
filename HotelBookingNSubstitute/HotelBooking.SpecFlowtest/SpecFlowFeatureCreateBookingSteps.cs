using System;
using TechTalk.SpecFlow;
using HotelBooking.BusinessLogic;
using HotelBooking.Data.Repositories;
using HotelBooking.Models;
using NSubstitute;
using NUnit.Framework;

namespace HotelBooking.SpecFlowtest
{
    [Binding]
    public class SpecFlowFeatureCreateBookingSteps
    {
        private DateTime startDate;
        private DateTime endDate;

        [Given(@"I have the entered a (.*)(.*) startDate")]
        public void GivenIHaveTheEnteredAStartDate(string p0,DateTime p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have also entered a (.*)(.*) endDate")]
        public void GivenIHaveAlsoEnteredAEndDate(string p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"There are available rooms")]
        public void GivenThereAreAvailableRooms()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press Create")]
        public void WhenIPressCreate()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"A new booking should be created")]
        public void ThenANewBookingShouldBeCreated()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
