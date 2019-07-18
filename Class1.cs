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
        public showErrorForm showErrorForm = new showErrorForm();


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
            //防止刚打开fiddler时，有数据进来但窗口还没初始化完成
            while (!oView.IsHandleCreated)
            {
                ;
            }

            oView.Invoke(new EventHandler(delegate
            {
                JArray jsons = new JArray();
                string url = oSession.fullUrl;
                if (url.Contains("log.dc.cn"))
                {
                    string body = oSession.GetRequestBodyAsString();
                    try
                    {
                        body = HttpUtility.UrlDecode(body);
                        body = Lis2013HISWSTest.ZipHelper.GZipDecompressString(body);
                        body = body.Trim();
                    }
                    catch
                    {
                        showErrorForm.setErrorTextToRich("body解码 报错：\n");
                        showErrorForm.Show();
                        showErrorForm.TopMost = true;
                    }

                    if (body.Length > 10)
                    {
                        try
                        {
                            body = HttpUtility.UrlDecode(body);
                            body = body.Substring(13, body.Length - 14);
                            jsons = JArray.Parse(body);
                        }
                        catch
                        {
                            showErrorForm.setErrorTextToRich("body转JArray 报错：\n" + body);
                            showErrorForm.Show();
                            showErrorForm.TopMost = true;
                        }
                        
                        oView.addData(jsons);                                        
                    }
                }
            }));
        }
        
        public void AutoTamperResponseBefore(Session oSession) { }
        public void AutoTamperResponseAfter(Session oSession) { }
        public void OnBeforeReturningError(Session oSession) { }
    }


}
