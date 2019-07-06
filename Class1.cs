using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Fiddler;
using System.Windows.Forms;
using System.Web;
using System.IO;
using System.IO.Compression;
using Newtonsoft.Json.Linq;

[assembly: Fiddler.RequiredVersion("2.3.5.0")]

namespace DCviewer
{
    
    
    public class Violin : IAutoTamper    // Ensure class is public, or Fiddler won't see it!
    {
        string sUserAgent = "";
        ViewPanel oView;
        

        //TabPage oPage = null;



        public Violin()
        {
            /* NOTE: It's possible that Fiddler UI isn't fully loaded yet, so don't add any UI in the constructor.

               But it's also possible that AutoTamper* methods are called before OnLoad (below), so be
               sure any needed data structures are initialized to safe values here in this constructor */

            sUserAgent = "Violin";
            oView = new ViewPanel(); //UserControl1 is a Windows Forms UserControl class
        }

        //Required Function
        public void OnLoad()
        {

            //oPage.ImageIndex = (int)SessionIcons.Timeline;  //This sets the Icon image used in the tab

            
            oView.Dock = DockStyle.Fill;
            TabPage oPage = new TabPage("DCviewer");
            oPage.Controls.Add(oView);

            FiddlerApplication.UI.tabsViews.TabPages.Add(oPage);

            
        }

        //Required Function
        public void OnBeforeUnload()
        {
        }

        public void AutoTamperRequestBefore(Session oSession)
        {
            oSession.oRequest["User-Agent"] = sUserAgent;

            
            
                         
        }
        public void AutoTamperRequestAfter(Session oSession)
        {
            oView.Invoke(new EventHandler(delegate
            {
                string url = oSession.fullUrl;
                if (url.Contains("log.dc.cn"))
                {
                    string body = oSession.GetRequestBodyAsString();
                    body = HttpUtility.UrlDecode(body);
                    body = Lis2013HISWSTest.ZipHelper.GZipDecompressString(body);
                    body = body.Trim();

                    if (body.Length > 10)
                    {                        
                        body = HttpUtility.UrlDecode(body);
                        body = body.Substring(13, body.Length - 14);
                        JArray jsons = JArray.Parse(body);
                        oView.addData(jsons);
                        //foreach (var ajson in jsons)
                        //{                            
                        //    oView.addData(ajson.ToString());
                        // test
                        //}                        
                    }
                }
            }));
        }
        
        public void AutoTamperResponseBefore(Session oSession) { }
        public void AutoTamperResponseAfter(Session oSession) { }
        public void OnBeforeReturningError(Session oSession) { }
    }


}
