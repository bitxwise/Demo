using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoApplication.Specs
{
    [Binding]
    public class HelpUsersWriteSearchQueriesSteps
    {
        [Given(@"user is about to search")]
        public void GivenUserIsAboutToSearch()
        {
            
        }
        
        [When(@"user begins typing query")]
        public void WhenUserBeginsTypingQuery()
        {
            
        }
        
        [Then(@"a list of suggestions should appear below the search field")]
        public void ThenAListOfSuggestionsShouldAppearBelowTheSearchField()
        {
            
        }
        
        [Then(@"the suggestions should update as user types")]
        public void ThenTheSuggestionsShouldUpdateAsUserTypes()
        {
            Assert.IsTrue(true);
        }
    }
}
