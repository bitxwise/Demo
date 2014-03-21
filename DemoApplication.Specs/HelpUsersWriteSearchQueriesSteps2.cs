// Consider using WatiN test recorder [http://watintestrecord.sourceforge.net/ ]
using System;
using TechTalk.SpecFlow;
using WatiN.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.Threading;

namespace DemoApplication.Specs
{
    [Binding]
    public class HelpUsersWriteSearchQueriesSteps2
    {
        private static IEStaticInstanceHelper _ieStaticInstanceHelper;

        private static IE Browser
        {
            get { return _ieStaticInstanceHelper.IE; }
        }

        #region Construction

        public HelpUsersWriteSearchQueriesSteps2()
        {
            Initialize();
        }

        ~HelpUsersWriteSearchQueriesSteps2()
        {
            _ieStaticInstanceHelper = null;
        }

        [ClassInitialize]
        public static void Initialize()
        {
            _ieStaticInstanceHelper = new IEStaticInstanceHelper();
            _ieStaticInstanceHelper.IE = new IE();
        }

        #endregion Construction

        [Given(@"user is at Google search page")]
        public void GivenUserIsAtGoogleSearchPage()
        {
            Browser.GoTo("http://www.google.com");
        }

        [When(@"user searches for WatiN")]
        public void WhenUserSearchesForWatiN()
        {
            try
            {
                Browser.TextField(Find.ByName("q")).TypeText("WatiN");
                Browser.Button(Find.ByName("btnK")).Click();
            }
            #region Clean Up
            catch { RemoveBrowser(); throw; }
            finally
            {
                Browser.GoTo("http://www.google.com/search?q=WatiN");
            }
            #endregion Clean Up
        }

        [Then(@"browser should contain WatiN in results")]
        public void ThenBrowserShouldContainWatiNInResults()
        {
            try
            {
                Assert.IsTrue(Browser.ContainsText("WatiN"));
            }
            #region Clean Up
            catch { throw; }
            finally { RemoveBrowser(); }
            #endregion Clean Up
        }

        private static void RemoveBrowser()
        {
            if(Browser != null)
            {
                Browser.GoTo("about:blank");

                var thread = new Thread(() => {
                    Browser.Close();
                });

                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
            }
        }
    }
}